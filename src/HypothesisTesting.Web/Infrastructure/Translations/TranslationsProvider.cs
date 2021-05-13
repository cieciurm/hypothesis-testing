using System.IO;
using HypothesisTesting.Domain.Ports.Translations;

namespace HypothesisTesting.Web.Infrastructure.Translations
{
    public class TranslationsProvider : ITranslationsProvider
    {
        public string GetTranslations(string lang) 
        {
            var translations = File.ReadAllText($"Data/{lang}.json");

            return translations;
        }
    }
}
