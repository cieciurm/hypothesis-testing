using System;
using HypothesisTesting.Adapters.AccordNET.Statistics;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using Moq;
using Shouldly;
using Xunit;

namespace HypothesisTesting.Adapters.AccordNET.Tests.Statistics
{
    public class MannWhitneyTestTests
    {
        private readonly MannWhitneyTest _test = new MannWhitneyTest(Mock.Of<IExecutionLogger>(), Mock.Of<ITranslator>());

        [Fact]
        public void Calculate_WhenDataProvided_ThenShouldCalculateCorrectly()
        {
            // Arrange
            var s1 = new[] { 2.0, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 7, 8 };
            var s2 = new[] { 2.0, 2, 3, 3, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8 };

            // Act
            Func<double> pValue = () => _test.Calculate(new InputData(s1, s2));

            // Assert
            pValue.ShouldNotThrow();
            pValue().ShouldBeInRange(0.015, 0.018);
        }
    }
}
