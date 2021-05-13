using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports
{
    public interface INormalDistributionTest
    {
        bool IsNormalDistribution(DataSeries dataSeries);
    }
}
