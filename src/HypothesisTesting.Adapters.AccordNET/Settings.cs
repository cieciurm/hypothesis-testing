namespace HypothesisTesting.Adapters.AccordNET
{
    internal static class Settings
    {
        public const double Threshold = 0.05;

        public static bool IsHypothesisTrue(double pValue) => pValue >= Threshold;
    }
}
