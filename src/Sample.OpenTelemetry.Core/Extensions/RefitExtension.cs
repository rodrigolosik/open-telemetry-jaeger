using Microsoft.Extensions.DependencyInjection;
using Refit;
using Sample.OpenTelemetry.Core.Configuration;
using Sample.OpenTelemetry.Core.Repositories.Interfaces;

namespace Sample.OpenTelemetry.Core.Extensions
{
    public static class RefitExtension
    {
        public static void AddRefit(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddRefitClient<IBankRepository>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(appSettings?.HttpClients?.BrasilApi?.BaseUrl ?? string.Empty);
            });
        }
    }
}
