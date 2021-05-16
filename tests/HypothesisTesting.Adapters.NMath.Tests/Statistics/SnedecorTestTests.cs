using HypothesisTesting.Adapters.NMath.Statistics;
using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using Moq;
using Shouldly;
using Xunit;

namespace HypothesisTesting.Adapters.NMath.Tests.Statistics
{
    public class SnedecorTestTests
    {
        private readonly SnedecorTest _snedecorTest = new SnedecorTest(Mock.Of<IExecutionLogger>(), Mock.Of<ITranslator>());

        [Theory]
        [InlineData(
            new[] { 0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17 },
            new[] { 1.36, 0.63, 4.79, -1.59, 2.72, -1.65, -0.58, 0.76, -2.26, 2.28, -0.19, 2.94, 0.56, -2.97, -2.03, 2.35, -0.25, 1.69, 0.62, 4.2 },
            true)]
        [InlineData(
            new[] { 2.09, 5.12, 5.99, -2.89, -4.99, -3.19, 14.36, 1.55, -2.89, -6.73, -2.29, -9.7, 0.14, 9.98, 3.71 },
            new[] { 1.36, 0.63, 4.79, -1.59, 2.72, -1.65, -0.58, 0.76, -2.26, 2.28, -0.19, 2.94, 0.56, -2.97, -2.03, 2.35, -0.25, 1.69, 0.62, 4.2 },
            false)]
        public void IsVarianceEqual_WhenDataProvided_ThenDetectsIfVarianceIsEqual(double[] s1, double[] s2, bool expected)
        {
            // Act
            var result = _snedecorTest.IsVarianceEqual(new InputData(s1, s2), Constants.DefaultSignificance);

            // Assert
            result.ShouldBe(expected);
        }
    }
}
