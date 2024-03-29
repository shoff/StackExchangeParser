﻿namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Domain.Models;
    using Elasticsearch.Models;
    using Votes;

    public class StackExchangeVoteProfile : Profile
    {
        public StackExchangeVoteProfile()
        {
            this.CreateMap<Vote, MongoDb.Entities.Vote>().ConvertUsing<DomainVoteToMongoDb>();
            this.CreateMap<MongoDb.Entities.Vote, IVote>().ConvertUsing<MongoDbVoteToDomain>();
            this.CreateMap<IVote, ElasticVote>().ConvertUsing<IVoteToElasticVote>();
        }
    }
}