namespace HypothesisTesting.Domain.Ports.Translations
{
    public interface ITranslator
    {
        string Translate(string key);

        string Translate(string key, params object[] values);
    }
}
