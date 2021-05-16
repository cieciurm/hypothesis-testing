using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using static HypothesisTesting.Domain.Constants;

namespace HypothesisTesting.Domain.Strategies
{
    public class IndependentNominalStrategy : BaseNominalStrategy
    {
        public override string SampleType => SamplesTypes.Independent;

        public IndependentNominalStrategy(IContingencyMatrixCalculator contingencyMatrixCalculator)
            : base(contingencyMatrixCalculator)
        {
        }

        protected override OutputData Execute(int[,] contingencyMatrix)
        {
            // Fisher
            return OutputData.Error();
        }
    }
}
