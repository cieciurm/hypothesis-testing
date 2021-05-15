namespace HypothesisTesting.Adapters.AccordNET
{
    internal static class Settings
    {
        public const double Significance = 0.05;

        public static bool IsHypothesisTrue(double pValue) => pValue >= Significance;
    }
}
