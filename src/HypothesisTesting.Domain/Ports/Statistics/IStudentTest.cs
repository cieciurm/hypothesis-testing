using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    public interface IStudentTest
    {
        double Calculate(InputData inputData, bool equalVariance);
    }
}
