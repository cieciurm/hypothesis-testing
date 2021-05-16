using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;

namespace HypothesisTesting.Domain.Strategies
{
    public class PairedNominalStrategy : BaseNominalStrategy
    {
        public override string SampleType => Constants.SamplesTypes.Paired;

        public PairedNominalStrategy(IContingencyMatrixCalculator contingencyMatrixCalculator)
            : base(contingencyMatrixCalculator)
        {
        }

        protected override OutputData Execute(int[,] contingencyMatrix)
        {
            // McNemar
            return OutputData.Error();
        }
    }
}