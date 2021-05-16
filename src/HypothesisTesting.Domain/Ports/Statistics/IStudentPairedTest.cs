using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    public interface IStudentPairedTest
    {
        double Calculate(InputData inputData);
    }
}
