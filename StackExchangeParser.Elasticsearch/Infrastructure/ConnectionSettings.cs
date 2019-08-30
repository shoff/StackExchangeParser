// ReSharper disable InconsistentNaming
namespace StackExchangeParser.Elasticsearch.Infrastructure
{
    using System;
    using global::Elasticsearch.Net;
    using Microsoft.Extensions.Logging;

    /*
        var connection = new AConnection();
        var connectionPool = new AConnectionPool(new Uri("http://localhost:9200"));
        var settings = new AConnectionSettings(connectionPool, connection);
        settings.IsDisposed.Should().BeFalse();
        connectionPool.IsDisposed.Should().BeFalse();
        connection.IsDisposed.Should().BeFalse();
     */

    public class ConnectionSettings : Nest.ConnectionSettings, IConnectionSettings
    {
        private readonly ILogger<ConnectionSettings> logger;
        public const string POC_USER_AGENT = "Identifix POC App";

        public ConnectionSettings(
            ILogger<ConnectionSettings> logger,
            IConnectionPool pool,
            IConnection connection)
            : base(pool, connection)
        {
            this.logger = logger;
            this.DisableDirectStreaming();
            this.ThrowExceptions(alwaysThrow: true);
            this.PrettyJson();
            // TODO
            // this.BasicAuthentication();
            this.DeadTimeout(TimeSpan.FromSeconds(10));
            this.EnableDebugMode(l => this.logger.LogDebug($"{l.DebugInformation}"));
            this.MaximumRetries(10);
            this.UserAgent(POC_USER_AGENT);
        }

        public bool IsDisposed { get; private set; }

        protected override void DisposeManagedResources()
        {
            this.IsDisposed = true;
            base.DisposeManagedResources();
        }
    }
}