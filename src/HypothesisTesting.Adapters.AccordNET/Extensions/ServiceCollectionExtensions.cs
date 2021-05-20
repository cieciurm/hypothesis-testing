using HypothesisTesting.Adapters.AccordNET.Statistics;
using HypothesisTesting.Domain.Ports.Statistics;
using Microsoft.Extensions.DependencyInjection;

namespace HypothesisTesting.Adapters.AccordNET.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccordNet(this IServiceCollection services) => services
            .AddScoped<INormalDistributionTest, NormalDistributionTest>()
            .AddScoped<ISnedecorTest, SnedecorTest>()
            .AddScoped<IMannWhitneyTest, MannWhitneyTest>()
            .AddScoped<IStudentTest, StudentTest>()
            .AddScoped<IStudentPairedTest, StudentPairedTest>()
            .AddScoped<IWilcoxonSignedRankTest, WilcoxonSignedRankTest>()
            .AddScoped<IMcNemarTest, McNemarTestImpl>()
            .AddScoped<IFisherTest, FisherTest>();
    }
}
