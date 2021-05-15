using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using static HypothesisTesting.Domain.Constants;

namespace HypothesisTesting.Domain.Strategies
{
    public class IndependentOrdinalStrategy : IStrategy
    {
        public string ScaleMeasure => ScaleMeasures.Ordinal;
        public string SampleType => SamplesTypes.Independent;

        private readonly IMannWhitneyTest _mannWhitneyTest;

        public IndependentOrdinalStrategy(IMannWhitneyTest mannWhitneyTest)
        {
            _mannWhitneyTest = mannWhitneyTest;
        }

        public OutputData Execute(InputData input)
        {
            var pValue = _mannWhitneyTest.Calculate(input);

            return OutputData.Success(pValue);
        }
    }
}
