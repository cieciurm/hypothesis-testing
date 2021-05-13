using HypothesisTesting.Domain.Ports.Translations;

namespace HypothesisTesting.Web.Infrastructure.Translations
{
    public class LanguageProvider : ILanguageProvider
    {
        private static string _language;

        public string Language => _language;
        
        public void SetLanguage(string language)
        {
            _language = language;
        }
    }
}
