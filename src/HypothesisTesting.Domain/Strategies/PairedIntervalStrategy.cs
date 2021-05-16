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
        private readonly IStudentPairedTest _studentPairedTest;
        private readonly IWilcoxonSignedRankTest _wilcoxonTest;

        public PairedIntervalStrategy(
            INormalDistributionTest normalDistributionTest,
            IStudentPairedTest studentPairedTest,
            IWilcoxonSignedRankTest wilcoxonTest)
        {
            _normalDistributionTest = normalDistributionTest;
            _studentPairedTest = studentPairedTest;
            _wilcoxonTest = wilcoxonTest;
        }

        public OutputData Execute(InputData input)
        {
            var isXNormalDistribution = _normalDistributionTest.IsNormalDistribution(input.XValues, input.Significance);
            var isYNormalDistribution = _normalDistributionTest.IsNormalDistribution(input.YValues, input.Significance);

            double pValue;
            if (isXNormalDistribution && isYNormalDistribution)
            {
                pValue = _studentPairedTest.Calculate(input);
            }
            else
            {
                pValue = _wilcoxonTest.Calculate(input);
            }

            return OutputData.Success(pValue);
        }
    }
}
