using Microsoft.Extensions.DependencyInjection;
using Sample.OpenTelemetry.Core.Services;

namespace Sample.OpenTelemetry.Core.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBankService, BankService>();
        }
    }
}
