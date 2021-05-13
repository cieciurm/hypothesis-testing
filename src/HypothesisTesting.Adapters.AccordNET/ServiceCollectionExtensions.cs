using HypothesisTesting.Domain.Ports;
using HypothesisTesting.Domain.Ports.Statistics;
using Microsoft.Extensions.DependencyInjection;

namespace HypothesisTesting.Adapters.AccordNET
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccordNet(this IServiceCollection services)
        {
            services.AddScoped<INormalDistributionTest, NormalDistributionTest>();
            services.AddScoped<IMannWhitneyTest, MannWhitneyTest>();
            services.AddScoped<ISnedecorTest, SnedecorTest>();

            return services;
        }
    }
}
