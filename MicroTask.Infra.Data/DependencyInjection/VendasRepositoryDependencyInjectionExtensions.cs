using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace MicroTask.Infra.Data.DependencyInjection
{
    public static class VendasRepositoryDependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraData(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(nameof(service));
            ArgumentNullException.ThrowIfNull(nameof(configuration));

            service.AddScoped<IDbConnection>(db =>
                new SqlConnection(configuration.GetConnectionString("UrlBase")));

            service.AddTransient<IVendasRepository, VendasRepository>();

            return service;
        }
    }
}
