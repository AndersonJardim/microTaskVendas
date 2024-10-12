using Microsoft.Extensions.DependencyInjection;
using MicroTask.Application.Service;
using MicroTask.Domain.Interface;

namespace MicroTask.Application.DependencyInjection
{
    public static class VendasApplicationDependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection service)
        {
            ArgumentNullException.ThrowIfNull(nameof(service));

            service.AddTransient<IVendasService, VendasService>();

            return service;
        }
    }
}
