using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Domain.Ports.Statistics
{
    /// <summary>
    /// https://mathcracker.com/contingency-table-calculator
    /// </summary>
    public interface IContingencyMatrixCalculator
    {
        int[,] Calculate(InputData inputData);
    }
}
