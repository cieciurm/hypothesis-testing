using HypothesisTesting.Domain.Ports.Translations;

namespace HypothesisTesting.Web.Models
{
    public abstract class BaseViewModel
    {
        public string Language { get; }

        private readonly ITranslator _translator;

        protected BaseViewModel(string language, ITranslator translator)
        {
            Language = language;
            _translator = translator;
        }

        public string GetTranslation(string key) => _translator.Translate(key);
    }
}
