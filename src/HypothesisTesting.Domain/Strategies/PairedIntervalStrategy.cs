using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using static HypothesisTesting.Domain.Constants;

namespace HypothesisTesting.Domain.Strategies
{
    public class PairedIntervalStrategy : IStrategy
    {
        public string SampleType => SamplesTypes.Paired;

        public string ScaleMeasure => ScaleMeasures.Interval;

        private readonly INormalDistributionTest _normalDistributionTest;

        public PairedIntervalStrategy(INormalDistributionTest normalDistributionTest)
        {
            _normalDistributionTest = normalDistributionTest;
        }

        public OutputData Execute(InputData input)
        {
            var isXNormalDistribution = _normalDistributionTest.IsNormalDistribution(input.XValues, input.Significance);
            var isYNormalDistribution = _normalDistributionTest.IsNormalDistribution(input.YValues, input.Significance);

            if (isXNormalDistribution && isYNormalDistribution)
            {
                // TStudent
            }
            else
            {
                // Wilcoxon
            }

            return OutputData.Error();
        }
    }
}
