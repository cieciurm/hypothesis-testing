using System.Collections.Generic;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Statistics;
using Shouldly;
using Xunit;

namespace HypothesisTesting.Domain.Tests.Statistics
{
    public class ContingencyMatrixCalculatorTests
    {
        private readonly ContingencyMatrixCalculator _calculator = new ContingencyMatrixCalculator();

        [Theory]
        [MemberData(nameof(Data))]
        public void Calculate(double[] s1, double[] s2, int[,] expected)
        {
            // Act
            var matrix = _calculator.Calculate(new InputData(s1, s2));

            // Assert
            matrix.ShouldBe(expected);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { new[] { 1.0, 2, 3, 4 }, new[] { 1.0, 2, 1, 2 }, new[,]
            {
                { 1, 0 },
                { 0, 1 },
                { 1, 0 },
                { 0, 1 }
            } },
            new object[] { new[] { 1.0, 2, 3, 4, 5 }, new[] { 6.0, 7, 8, 9, 10 }, new[,]
            {
                { 1, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1 },
            } },
        };
    }
}
