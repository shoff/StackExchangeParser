namespace StackExchangeParser.Elasticsearch.Infrastructure
{
    using System;
    using Configuration;
    using global::Elasticsearch.Net;
    using Microsoft.Extensions.Options;

    public class ConnectionPool : SingleNodeConnectionPool
    { 
        public ConnectionPool(
            IOptions<ElasticSearch> options,
            IDateTimeProvider dateTimeProvider = null)
            : base(new Uri(
                $"{options.Value.Scheme}{options.Value.Server}/{options.Value.Port}"), dateTimeProvider)
        {
        }


        public bool IsDisposed { get; private set; }

        protected override void DisposeManagedResources()
        {
            this.IsDisposed = true;
            base.DisposeManagedResources();
        }
    }
}