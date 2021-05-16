using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;

namespace HypothesisTesting.Adapters.AccordNET.Statistics
{
    public class ContingencyMatrixCalculator : IContingencyMatrixCalculator
    {
        public int[,] Calculate(InputData inputData)
        {
            return new int[0,0];
        }
    }
}
