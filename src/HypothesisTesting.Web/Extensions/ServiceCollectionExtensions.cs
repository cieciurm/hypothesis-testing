using HypothesisTesting.Adapters.AccordNET.Extensions;
using HypothesisTesting.Adapters.NMath.Extensions;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using HypothesisTesting.Domain.Strategies;
using HypothesisTesting.Web.Infrastructure.Translations;
using Microsoft.Extensions.DependencyInjection;

namespace HypothesisTesting.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHypothesisTesting(this IServiceCollection services)
        {
            services.AddAccordNet();
            services.AddNMath();

            services.AddScoped<IStrategy, IndependentIntervalStrategy>();
            services.AddScoped<IExecutor, Executor>();
            services.AddScoped<IExecutionLogger, ExecutionLogger>();
            
            services.AddScoped<ITranslationsProvider, TranslationsProvider>();
            services.AddScoped<ITranslator, Translator>();
            services.AddScoped<ILanguageProvider, LanguageProvider>();

            return services;
        }
    }
}
