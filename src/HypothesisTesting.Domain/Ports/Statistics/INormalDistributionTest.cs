using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    public interface INormalDistributionTest
    {
        bool IsNormalDistribution(DataSeries dataSeries);
    }
}
