using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Sample.OpenTelemetry.Core.Configuration;

namespace Sample.OpenTelemetry.Core.Extensions
{
    public static class OpenTelemetryExtension
    {
        public static void AddOpenTelemetry(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddOpenTelemetry()
                .WithTracing(telemetry =>
            {
                var resourceBuiler = ResourceBuilder
                .CreateDefault()
                .AddService(appSettings?.DistributedTracing?.Jaeger?.ServiceName ?? string.Empty);

                telemetry
                .SetResourceBuilder(resourceBuiler)
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .SetSampler(new AlwaysOnSampler())
                .AddJaegerExporter(jaegerOptions =>
                {
                    jaegerOptions.AgentHost = appSettings?.DistributedTracing?.Jaeger?.Host;
                    jaegerOptions.AgentPort = appSettings?.DistributedTracing?.Jaeger?.Port ?? 0;
                });
            });
        }
    }
}
