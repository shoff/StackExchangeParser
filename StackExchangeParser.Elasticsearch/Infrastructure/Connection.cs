namespace StackExchangeParser.Elasticsearch.Infrastructure
{
    using global::Elasticsearch.Net;

    public class Connection : InMemoryConnection
    {
        public bool IsDisposed { get; private set; }

        protected override void DisposeManagedResources()
        {
            this.IsDisposed = true;
            base.DisposeManagedResources();
        }
    }
}