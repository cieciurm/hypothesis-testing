using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using static HypothesisTesting.Domain.Constants;

namespace HypothesisTesting.Domain.Strategies
{
    public class IndependentNominalStrategy : BaseNominalStrategy
    {
        public override string SampleType => SamplesTypes.Independent;

        private readonly IFisherTest _fisherTest;

        public IndependentNominalStrategy(IContingencyMatrixCalculator contingencyMatrixCalculator, IFisherTest fisherTest)
            : base(contingencyMatrixCalculator)
        {
            _fisherTest = fisherTest;
        }

        protected override OutputData Execute(int[,] contingencyMatrix, double significance)
        {
            var pValue = _fisherTest.Calculate(contingencyMatrix, significance);

            return OutputData.Success(pValue);
        }
    }
}
