using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Strategies
{
    public abstract class BaseNominalStrategy : IStrategy
    {
        public abstract string SampleType { get; }

        public string ScaleMeasure => Constants.ScaleMeasures.Nominal;

        public OutputData Execute(InputData input)
        {
            // Contingency table

            // Test Fisher
            // Test McNemar

            return OutputData.Error();
        }
    }
}
