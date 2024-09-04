using Microsoft.Extensions.DependencyInjection.Extensions;
using OnyxCenterSourceTest.Tasks.Task2;
using OnyxCenterSourceTest.Tasks.Task3;
using VatServices;

namespace OnyxCenterSourceTest
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddLocalServices(this  IServiceCollection services)
        {
            services.TryAddSingleton(TimeProvider.System);
            services.TryAddSingleton<ILogWriter>(new FileLogWriter(@"E:\test\onyx\logs.txt"));
            services.TryAddScoped<Tasks.Task2.ILogger, ReLogger>();
            services.TryAddScoped<IVatVerifier, Tasks.Task3.VatVerifier>();
            services.TryAddScoped<checkVatPortTypeClient>();
            services.TryAddScoped<IVatVerifierClient, WsdlVatVerifierClient>();

            return services;
        }
    }
}
