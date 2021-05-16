using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Web.Infrastructure.Input
{
    public static class InputValidator
    {
        public static bool IsValid(string sampleType, DataSeries x, DataSeries y)
        {
            if (sampleType == Constants.SamplesTypes.Independent)
            {
                return true;
            }

            return x.Values.Length == y.Values.Length;
        }
    }
}
