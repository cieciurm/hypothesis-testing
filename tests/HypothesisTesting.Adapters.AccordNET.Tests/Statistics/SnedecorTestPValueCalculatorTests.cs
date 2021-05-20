using System.Collections.Generic;
using Accord.Statistics;
using Accord.Statistics.Testing;
using HypothesisTesting.Adapters.AccordNET.Statistics;
using HypothesisTesting.Domain;
using Shouldly;
using Xunit;

namespace HypothesisTesting.Adapters.AccordNET.Tests.Statistics
{
    public class SnedecorTestPValueCalculatorTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Calculate_WhenDataProvided_ThenCalculatesPValueCorrectly(double[] s1, double[] s2, double expectedPValue)
        {
            // Arrange
            var f = CalculateFTest(s1, s2);

            // Act
            var pValue = SnedecorTest.PValueCalculator.Calculate(f);

            // Assert
            pValue.ShouldBe(expectedPValue, TestConsts.Tolerance);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                new[] { 0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17 },
                new[] { 1.36, 0.63, 4.79, -1.59, 2.72, -1.65, -0.58, 0.76, -2.26, 2.28, -0.19, 2.94, 0.56, -2.97, -2.03, 2.35, -0.25, 1.69, 0.62, 4.2 },
                0.9956
            },
            new object[]
            {
                new[] { 2.09, 5.12, 5.99, -2.89, -4.99, -3.19, 14.36, 1.55, -2.89, -6.73, -2.29, -9.70, 0.14, 9.98, 3.71 },
                new[] { 1.36, 0.63, 4.79, -1.59, 2.72, -1.65, -0.58, 0.76, -2.26, 2.28, -0.19, 2.94, 0.56, -2.97, -2.03, 2.35, -0.25, 1.69, 0.62, 4.20 },
                0.000028
            }
        };

        private static FTest CalculateFTest(double[] s1, double[] s2)
        {
            var var1 = s1.Variance();
            var var2 = s2.Variance();

            var f = new FTest(var1, var2, s1.Length - 1, s2.Length - 1, TwoSampleHypothesis.ValuesAreDifferent)
            {
                Size = Constants.DefaultSignificance
            };

            return f;
        }
    }
}
