namespace StackExchangeParser.Infrastructure.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Models;
    using Nest;

    public class QueryHandler : IRequestHandler<QueryModel, ISearchResponse<object>>
    {
        public Task<ISearchResponse<object>> Handle(QueryModel request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}