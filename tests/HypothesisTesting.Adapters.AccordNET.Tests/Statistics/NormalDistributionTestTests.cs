using System.Linq;
using HypothesisTesting.Adapters.AccordNET.Statistics;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using Moq;
using Shouldly;
using Xunit;

namespace HypothesisTesting.Adapters.AccordNET.Tests.Statistics
{
    public class NormalDistributionTestTests
    {
        private readonly NormalDistributionTest _test;

        private readonly Mock<ITranslator> _translator = new Mock<ITranslator>();

        public NormalDistributionTestTests()
        {
            _test = new NormalDistributionTest(Mock.Of<IExecutionLogger>(), _translator.Object);
        }

        [Theory]
        [InlineData(new[] { 0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17 }, true, "Shapiro-Wilk")]
        [InlineData(new[] { 0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17, 0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17, 0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17, 0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17 }, true, "Kolmogorov-Smirnov")]
        [InlineData(new[] { 1.0, 1.0, 1.0, 1.0, 2.0 }, false, "Shapiro-Wilk")]
        [InlineData(new[] { 1.0, 1.0, 1.0, 1.0, 1.0 }, false, "Shapiro-Wilk")]
        public void IsNormalDistribution_WhenDataProvided_ThenDetectsIfDistributionIsNormal(double[] sample, bool expectedIsNormal, string expectedTest)
        {
            // Act
            var result = _test.IsNormalDistribution(new DataSeries(sample));

            // Assert
            result.ShouldBe(expectedIsNormal);
            _translator.Verify(x => x.Translate(It.IsAny<string>(), It.Is<object[]>(y => y.Contains(expectedTest))));
        }
    }
}
