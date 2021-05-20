using System.Collections.Generic;
using HypothesisTesting.Adapters.AccordNET.Statistics;
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

        [Theory]
        [MemberData(nameof(Data))]
        public void Calculate_WhenDataProvided_ThenShouldCalculate(double[] s1, double[] s2, double expectedPValue)
        {
            // Act
            var result = _test.Calculate(new InputData(s1, s2));

            // Assert
            result.ShouldBe(expectedPValue, /* TODO */ 0.007);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                new[] { 1.0, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                new[] { 6.0, 7, 8, 9, 10, 11, 12, 13, 14, 15 },
                .00512
            },
            new object[]
            {
                new[] { 5.0, 15, 8, 10, 21, 22, 4, 4, 8, 12 },
                new[] { 3.0, 14 , 9, 8, 14, 20, 5, 6, 2, 9 },
                .06724
            }
        };
    }
}
