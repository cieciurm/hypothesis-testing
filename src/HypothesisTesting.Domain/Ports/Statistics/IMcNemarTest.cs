using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    /// <summary>
    /// https://www.graphpad.com/quickcalcs/McNemar1.cfm
    /// </summary>
    public interface IMcNemarTest
    {
        double Calculate(InputData inputData);
    }
}