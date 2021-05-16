using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using HypothesisTesting.Domain.Strategies;
using HypothesisTesting.Web.Infrastructure.Translations;
using Microsoft.Extensions.DependencyInjection;

namespace HypothesisTesting.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHypothesisTesting(this IServiceCollection services) => services
            .AddInfrastructure()
            .AddStrategies();

        private static IServiceCollection AddInfrastructure(this IServiceCollection services) => services
            .AddScoped<IExecutor, Executor>()
            .AddScoped<IExecutionLogger, ExecutionLogger>()
            .AddScoped<ITranslationsProvider, TranslationsProvider>()
            .AddScoped<ITranslator, Translator>()
            .AddScoped<ILanguageProvider, LanguageProvider>();

        private static IServiceCollection AddStrategies(this IServiceCollection services) => services
            .AddScoped<IStrategy, IndependentIntervalStrategy>()
            .AddScoped<IStrategy, IndependentOrdinalStrategy>()
            .AddScoped<IStrategy, IndependentNominalStrategy>()
            .AddScoped<IStrategy, PairedIntervalStrategy>()
            .AddScoped<IStrategy, PairedOrdinalStrategy>()
            .AddScoped<IStrategy, PairedNominalStrategy>();
    }
}
