namespace HypothesisTesting.Domain.Extensions
{
    public static class DoubleExtensions
    {
        public static string Round(this double d) => $"{d:F3}";
    }
}
