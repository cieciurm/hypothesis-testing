using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    /// <summary>
    /// https://www.socscistatistics.com/tests/mannwhitney/
    /// </summary>
    public interface IMannWhitneyTest
    {
        double Calculate(InputData inputData);
    }
}
