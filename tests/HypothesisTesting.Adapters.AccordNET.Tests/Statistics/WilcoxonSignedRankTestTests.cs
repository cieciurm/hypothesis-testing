using HypothesisTesting.Adapters.AccordNET.Statistics;
using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using Moq;
using Shouldly;
using Xunit;

namespace HypothesisTesting.Adapters.AccordNET.Tests.Statistics
{
    public class WilcoxonSignedRankTestTests
    {
        private readonly WilcoxonSignedRankTest _test = new WilcoxonSignedRankTest(Mock.Of<IExecutionLogger>(), Mock.Of<ITranslator>());

        [Fact]
        public void Calculate_WhenDataProvided_ThenShouldCalculate()
        {
            // Arrange
            var s1 = new[] { 1.0, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var s2 = new[] { 6.0, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // Act
            var result = _test.Calculate(new InputData(s1, s2));

            // Assert
            result.ShouldBeLessThan(Constants.DefaultSignificance);
        }
    }
}
