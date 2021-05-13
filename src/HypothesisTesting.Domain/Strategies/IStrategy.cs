using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Strategies
{
    public interface IStrategy
    {
        string ScaleMeasure { get; }

        string SampleType { get; }

        OutputData Execute(InputData input);
    }
}
