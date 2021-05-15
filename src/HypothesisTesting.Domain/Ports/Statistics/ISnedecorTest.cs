using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    public interface ISnedecorTest
    {
        bool IsVarianceEqual(InputData inputData, double significance);
    }
}
