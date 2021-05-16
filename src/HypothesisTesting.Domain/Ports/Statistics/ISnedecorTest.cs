using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    /// <summary>
    /// https://www.statskingdom.com/220VarF2.html
    /// </summary>
    public interface ISnedecorTest
    {
        bool IsVarianceEqual(InputData inputData, double significance);
    }
}
