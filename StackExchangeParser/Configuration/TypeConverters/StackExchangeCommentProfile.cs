namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Comments;
    using Domain.Models;
    using Elasticsearch.Models;

    public class StackExchangeCommentProfile : Profile
    {
        public StackExchangeCommentProfile()
        {
            // this.CreateMap<source,destination>
            this.CreateMap<Comment, MongoDb.Entities.Comment>().ConvertUsing<DomainCommentToMongoComment>();
            this.CreateMap<MongoDb.Entities.Comment, IComment>().ConvertUsing<MongoCommentToDomainComment>();
            this.CreateMap<IComment, ElasticComment>().ConvertUsing<ICommentToElasticComment>();
        }
    }
}