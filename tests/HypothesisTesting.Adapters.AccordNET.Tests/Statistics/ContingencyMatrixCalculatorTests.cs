using HypothesisTesting.Adapters.AccordNET.Statistics;
using HypothesisTesting.Domain.Models;
using Xunit;

namespace HypothesisTesting.Adapters.AccordNET.Tests.Statistics
{
    public class ContingencyMatrixCalculatorTests
    {
        private readonly ContingencyMatrixCalculator _calculator = new ContingencyMatrixCalculator();

        [Fact]
        public void Calculate()
        {
            // Arrange
            //var s1 = new[] { 1.0, 2, 3, 4 };
            //var s2 = new[] { 1.0, 2, 1, 2 };
            var s1 = new[] { 1.0, 2, 3, 4,5 };
            var s2 = new[] { 6.0, 7, 8, 9, 10 };

            // Act
            var matrix = _calculator.Calculate(new InputData(s1, s2));

            // Assert
        }

    }
}
