using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    /// <summary>
    /// https://www.socscistatistics.com/tests/fisher/default2.aspx
    /// </summary>
    public interface IFisherTest
    {
        double Calculate(InputData inputData);
    }
}
