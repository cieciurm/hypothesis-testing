using HypothesisTesting.Adapters.NMath.Statistics;
using HypothesisTesting.Domain.Ports.Statistics;
using Microsoft.Extensions.DependencyInjection;

namespace HypothesisTesting.Adapters.NMath.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNMath(this IServiceCollection services)
        {
            services.AddScoped<ISnedecorTest, SnedecorTest>();

            return services;
        }
    }
}
