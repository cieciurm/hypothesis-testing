using HypothesisTesting.Adapters.AccordNET.Statistics;
using HypothesisTesting.Domain.Ports.Statistics;
using Microsoft.Extensions.DependencyInjection;

namespace HypothesisTesting.Adapters.AccordNET.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccordNet(this IServiceCollection services)
        {
            services.AddScoped<INormalDistributionTest, NormalDistributionTest>();
            services.AddScoped<ISnedecorTest, SnedecorTest>();
            services.AddScoped<IMannWhitneyTest, MannWhitneyTest>();
            services.AddScoped<IStudentTest, StudentTest>();
            services.AddScoped<IStudentPairedTest, StudentPairedTest>();
            services.AddScoped<IWilcoxonSignedRankTest, WilcoxonSignedRankTest>();

            return services;
        }
    }
}
