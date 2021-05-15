namespace HypothesisTesting.Adapters.AccordNET
{
    internal static class HypothesisHelper
    {
        public static bool IsHypothesisTrue(double pValue, double significance) => pValue >= significance;
    }
}
