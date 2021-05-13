using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    public interface IMannWhitneyTest
    {
        double Calculate(InputData inputData);
    }
}
