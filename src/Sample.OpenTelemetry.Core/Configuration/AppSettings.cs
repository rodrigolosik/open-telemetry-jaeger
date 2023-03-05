namespace Sample.OpenTelemetry.Core.Configuration
{
    public class AppSettings
    {
        public DistributedTracingOptions? DistributedTracing { get; set; }
        public HttpClients? HttpClients { get; set; }
    }

    public class DistributedTracingOptions
    {
        public bool IsEnabled { get; set; }
        public JaegerOptions? Jaeger { get; set; }
    }

    public class JaegerOptions
    {
        public string? ServiceName { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
    }

    public class HttpClients
    {
        public BrasilApi? BrasilApi { get; set; }
    }

    public class BrasilApi
    {
        public string? BaseUrl { get; set; }
    }
}
