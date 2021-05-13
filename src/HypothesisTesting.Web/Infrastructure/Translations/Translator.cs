using System.Text.Json;
using HypothesisTesting.Domain.Ports.Translations;

namespace HypothesisTesting.Web.Infrastructure.Translations
{
    public class Translator  : ITranslator
    {
        private readonly ITranslationsProvider _translationsProvider;
        private readonly ILanguageProvider _languageProvider;

        private JsonDocument _json;

        public Translator(ITranslationsProvider translationsProvider, ILanguageProvider languageProvider)
        {
            _translationsProvider = translationsProvider;
            _languageProvider = languageProvider;
        }

        public string Translate(string key)
        {
            Initialize();

            if (_json.RootElement.TryGetProperty(key, out var element))
            {
                return element.GetString();
            }

            return "[Untranslated]";
        }

        public string Translate(string key, params object[] values)
        {
            Initialize();

            if (_json.RootElement.TryGetProperty(key, out var element))
            {
                return string.Format(element.GetString(), values);
            }

            return "[Untranslated]";
        }

        private void Initialize()
        {
            var lang = _languageProvider.Language;

            if (_json == null)
            {
                var translations = _translationsProvider.GetTranslations(lang);
                _json = JsonDocument.Parse(translations);
            }
        }
    }
}
