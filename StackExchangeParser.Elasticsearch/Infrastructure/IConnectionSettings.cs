namespace StackExchangeParser.Elasticsearch.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net.Security;
    using System.Security;
    using System.Security.Cryptography.X509Certificates;
    using global::Elasticsearch.Net;
    using Nest;

    public interface IConnectionSettings
    {
        bool IsDisposed { get; }
        Nest.ConnectionSettings DefaultIndex(string defaultIndex);
        Nest.ConnectionSettings DefaultFieldNameInferrer(Func<string, string> fieldNameInferrer);
        Nest.ConnectionSettings DefaultDisableIdInference(bool disable);
        Nest.ConnectionSettings DefaultMappingFor(Type documentType, Func<ClrTypeMappingDescriptor, IClrTypeMapping> selector);
        Nest.ConnectionSettings DefaultMappingFor(IEnumerable<IClrTypeMapping> typeMappings);
        Nest.ConnectionSettings EnableTcpKeepAlive(TimeSpan keepAliveTime, TimeSpan keepAliveInterval);
        Nest.ConnectionSettings MaximumRetries(int maxRetries);
        Nest.ConnectionSettings ConnectionLimit(int connectionLimit);
        Nest.ConnectionSettings SniffOnConnectionFault(bool sniffsOnConnectionFault);
        Nest.ConnectionSettings SniffOnStartup(bool sniffsOnStartup);
        Nest.ConnectionSettings SniffLifeSpan(TimeSpan? sniffLifeSpan);
        Nest.ConnectionSettings EnableHttpCompression(bool enabled);
        Nest.ConnectionSettings DisableAutomaticProxyDetection(bool disable);
        Nest.ConnectionSettings ThrowExceptions(bool alwaysThrow);
        Nest.ConnectionSettings DisablePing(bool disable);
        Nest.ConnectionSettings GlobalQueryStringParameters(NameValueCollection queryStringParameters);
        Nest.ConnectionSettings GlobalHeaders(NameValueCollection headers);
        Nest.ConnectionSettings RequestTimeout(TimeSpan timeout);
        Nest.ConnectionSettings PingTimeout(TimeSpan timeout);
        Nest.ConnectionSettings DeadTimeout(TimeSpan timeout);
        Nest.ConnectionSettings MaxDeadTimeout(TimeSpan timeout);
        Nest.ConnectionSettings MaxRetryTimeout(TimeSpan maxRetryTimeout);
        Nest.ConnectionSettings Proxy(Uri proxyAddress, string username, string password);
        Nest.ConnectionSettings Proxy(Uri proxyAddress, string username, SecureString password);
        Nest.ConnectionSettings PrettyJson(bool b);
        Nest.ConnectionSettings IncludeServerStackTraceOnError(bool b);
        Nest.ConnectionSettings DisableDirectStreaming(bool b);
        Nest.ConnectionSettings OnRequestCompleted(Action<IApiCallDetails> handler);
        Nest.ConnectionSettings OnRequestDataCreated(Action<RequestData> handler);
        Nest.ConnectionSettings BasicAuthentication(string username, string password);
        Nest.ConnectionSettings BasicAuthentication(string username, SecureString password);
        Nest.ConnectionSettings ApiKeyAuthentication(string id, SecureString apiKey);
        Nest.ConnectionSettings ApiKeyAuthentication(string id, string apiKey);
        Nest.ConnectionSettings EnableHttpPipelining(bool enabled);
        Nest.ConnectionSettings NodePredicate(Func<Node, bool> predicate);
        Nest.ConnectionSettings EnableDebugMode(Action<IApiCallDetails> onRequestCompleted);
        Nest.ConnectionSettings ServerCertificateValidationCallback(Func<object, X509Certificate, X509Chain, SslPolicyErrors, bool> callback);
        Nest.ConnectionSettings ClientCertificates(X509CertificateCollection certificates);
        Nest.ConnectionSettings ClientCertificate(X509Certificate certificate);
        Nest.ConnectionSettings ClientCertificate(string certificatePath);
        Nest.ConnectionSettings SkipDeserializationForStatusCodes(params int[] statusCodes);
        Nest.ConnectionSettings UserAgent(string userAgent);
        Nest.ConnectionSettings TransferEncodingChunked(bool transferEncodingChunked);
    }
}