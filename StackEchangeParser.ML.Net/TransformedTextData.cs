namespace StackExchangeParser.ML.Net
{
    public class TransformedTextData : TextData
    {
        public long TransformedTextDataId { get; set; }
        public float[] Features { get; set; }
        public string[] OutputTokens { get; set; }
    }
}