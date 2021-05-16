using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    /// <summary>
    /// https://www.socscistatistics.com/tests/studentttest/default.aspx
    /// </summary>
    public interface IStudentTest
    {
        double Calculate(InputData inputData, bool equalVariance);
    }
}
