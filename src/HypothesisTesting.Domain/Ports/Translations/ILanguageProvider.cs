namespace HypothesisTesting.Domain.Ports.Translations
{
    public interface ILanguageProvider
    {
        string Language { get; }

        void SetLanguage(string language);
    }
}
