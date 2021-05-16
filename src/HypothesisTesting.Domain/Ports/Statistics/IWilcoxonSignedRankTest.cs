using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    public interface IWilcoxonSignedRankTest
    {
        double Calculate(InputData inputData);
    }
}
