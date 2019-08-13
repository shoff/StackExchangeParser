namespace StackExchangeParser.ML.Net
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using Domain;
    using Microsoft.Extensions.Logging;
    using Microsoft.ML;
    using Microsoft.ML.Transforms.Text;
    using Zatoichi.Common.Infrastructure.Extensions;

    public class MLData : IMLData
    {
        private readonly ILogger<MLData> logger;
        private readonly IStackExchangeRepository repository;
        private readonly MLContext mlContext;

        public MLData(
            ILogger<MLData> logger,
            IStackExchangeRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
            // Create a new ML context, for ML.NET operations. It can be used for exception tracking and logging, 
            // as well as the source of randomness.
            this.mlContext = new MLContext();
        }


        public void MakeData()
        {
            var posts = this.repository.Posts();
            var dataView = this.mlContext.Data.LoadFromEnumerable(posts);

            //// A pipeline for converting text into numeric features.
            //// The following call to 'FeaturizeText' instantiates 'TextFeaturizingEstimator' with given parameters.
            //// The length of the output feature vector depends on these settings.
            var options = new TextFeaturizingEstimator.Options()
            {
                // Also output tokenized words
                OutputTokensColumnName = "OutputTokens",
                CaseMode = TextNormalizingEstimator.CaseMode.Lower,
                // Use ML.NET's built-in stop word remover
                StopWordsRemoverOptions = new StopWordsRemovingEstimator.Options() { Language = TextFeaturizingEstimator.Language.English },
                WordFeatureExtractor = new WordBagEstimator.Options() { NgramLength = 2, UseAllLengths = true },
                CharFeatureExtractor = new WordBagEstimator.Options() { NgramLength = 3, UseAllLengths = false },
            };
            var textPipeline = this.mlContext.Transforms.Text.FeaturizeText("Features", options, "Text");

            // Fit to data.
            var textTransformer = textPipeline.Fit(dataView);
            // Create the prediction engine to get the features extracted from the text.
            var predictionEngine = this.mlContext.Model.CreatePredictionEngine<TextData, TransformedTextData>(textTransformer);
            // Convert the text into numeric features.
            // var prediction = predictionEngine.Predict(posts[0]);
            var features = new BlockingCollection<Feature>();


            Parallel.ForEach(posts, p =>
            {
                try
                {
                    Console.WriteLine($"Now predicting {p.Id}");
                    var postPrediction = predictionEngine.Predict(new TextData
                    {
                        PostId = p.Id,
                        Text = p.Body
                    });
                    var feature = new Feature();
                    postPrediction.Features.Each(pf => feature.Values.Add(new FeatureValue {Value = pf}));
                    postPrediction.OutputTokens.Each(ot => feature.Tokens.Add(new FeatureToken {Token = ot}));
                    features.Add(feature);
                }
                catch (Exception e)
                {
                    this.logger.LogError(e, e.Message);
                }
            });


            //using (var context = new SEJapaneseDataContext())
            //{
            //    context.Features.AddRange(features.ToList());
            //    context.SaveChanges();
            //    //  context.BulkInsert(features.ToList());
            //}
            //// Print the length of the feature vector.
            //Console.WriteLine($"Number of Features: {prediction.Features.Length}");

            //// Print feature values and tokens.
            //Console.Write("Features: ");
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write($"{prediction.Features[i]:F4}  ");
            //}

            //Console.WriteLine($"\nTokens: {string.Join(",", prediction.OutputTokens)}");

            //  Expected output:
            //   Number of Features: 282
            //   Features: 0.0941  0.0941  0.0941  0.0941  0.0941  0.0941  0.0941  0.0941  0.0941  0.1881 ...
            //   Tokens: ml.net's,featurizetext,api,uses,composition,basic,transforms,convert,text,numeric,features.
        }
    }
}