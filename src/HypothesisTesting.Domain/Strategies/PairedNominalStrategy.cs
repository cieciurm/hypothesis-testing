using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;

namespace HypothesisTesting.Domain.Strategies
{
    public class PairedNominalStrategy : BaseNominalStrategy
    {
        public override string SampleType => Constants.SamplesTypes.Paired;

        private readonly IMcNemarTest _mcNemarTest;

        public PairedNominalStrategy(IContingencyMatrixCalculator contingencyMatrixCalculator, IMcNemarTest mcNemarTest)
            : base(contingencyMatrixCalculator)
        {
            _mcNemarTest = mcNemarTest;
        }

        protected override OutputData Execute(int[,] contingencyMatrix, double significance)
        {
            var pValue = _mcNemarTest.Calculate(contingencyMatrix, significance);

            return OutputData.Success(pValue);
        }
    }
}