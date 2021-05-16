using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;

namespace HypothesisTesting.Domain.Strategies
{
    public abstract class BaseNominalStrategy : IStrategy
    {
        public abstract string SampleType { get; }

        public string ScaleMeasure => Constants.ScaleMeasures.Nominal;

        private readonly IContingencyMatrixCalculator _contingencyMatrixCalculator;

        protected BaseNominalStrategy(IContingencyMatrixCalculator contingencyMatrixCalculator)
        {
            _contingencyMatrixCalculator = contingencyMatrixCalculator;
        }

        protected abstract OutputData Execute(int[,] contingencyMatrix);

        public OutputData Execute(InputData input)
        {
            var contingencyMatrix = _contingencyMatrixCalculator.Calculate(input);

            return Execute(contingencyMatrix);
        }
    }
}
