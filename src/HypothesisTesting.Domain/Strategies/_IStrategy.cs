using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Strategies
{
    public interface IStrategy
    {
        string SampleType { get; }

        string ScaleMeasure { get; }

        OutputData Execute(InputData input);
    }
}
