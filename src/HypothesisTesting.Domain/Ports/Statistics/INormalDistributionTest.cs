using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    /// <summary>
    /// https://scistatcalc.blogspot.com/2013/10/shapiro-wilk-test-calculator.html
    /// https://www.socscistatistics.com/tests/kolmogorov/default.aspx
    /// </summary>
    public interface INormalDistributionTest
    {
        bool IsNormalDistribution(DataSeries dataSeries, double significance);
    }
}
