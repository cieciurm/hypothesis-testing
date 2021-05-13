namespace HypothesisTesting.Domain.Ports.Translations
{
    public interface ITranslationsProvider
    {
        string GetTranslations(string lang);
    }
}
