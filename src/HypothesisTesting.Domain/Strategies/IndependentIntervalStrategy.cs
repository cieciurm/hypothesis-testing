using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports;
using HypothesisTesting.Domain.Ports.Statistics;

namespace HypothesisTesting.Domain.Strategies
{
    public class IndependentIntervalStrategy : IStrategy
    {
        public string ScaleMeasure => Constants.ScaleMeasures.Interval;
        public string SampleType => Constants.SamplesTypes.Independent;

        private readonly INormalDistributionTest _normalDistributionTest;
        private readonly IMannWhitneyTest _mannWhitneyTest;
        private readonly ISnedecorTest _snedecorTest;
        private readonly IStudentTest _studentTest;

        public IndependentIntervalStrategy(
            INormalDistributionTest normalDistributionTest,
            IMannWhitneyTest mannWhitneyTest,
            ISnedecorTest snedecorTest,
            IStudentTest studentTest)
        {
            _normalDistributionTest = normalDistributionTest;
            _mannWhitneyTest = mannWhitneyTest;
            _snedecorTest = snedecorTest;
            _studentTest = studentTest;
        }

        public OutputData Execute(InputData input)
        {
            var isXNormalDistribution = _normalDistributionTest.IsNormalDistribution(input.XValues);
            var isYNormalDistribution = _normalDistributionTest.IsNormalDistribution(input.YValues);

            if (!isXNormalDistribution || !isYNormalDistribution)
            {
                var pValue = _mannWhitneyTest.Calculate(input);

                return OutputData.Success(pValue);
            }

            if (_snedecorTest.IsVarianceEqual(input))
            {
                var pValue = _studentTest.Calculate(input, false);
                return OutputData.Success(pValue);
            }

            return OutputData.Error();
        }
    }
}
