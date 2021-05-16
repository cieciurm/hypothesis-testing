namespace HypothesisTesting.Domain.Services
{
    public static class HypothesisHelper
    {
        public static bool IsHypothesisTrue(double pValue, double significance) => pValue >= significance;
    }
}
