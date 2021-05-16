using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Strategies
{
    public class PairedOrdinalStrategy : IStrategy
    {
        public string SampleType => Constants.SamplesTypes.Paired;

        public string ScaleMeasure => Constants.ScaleMeasures.Ordinal;

        public OutputData Execute(InputData input)
        {
            // Wilcoxon

            return OutputData.Error();
        }
    }
}