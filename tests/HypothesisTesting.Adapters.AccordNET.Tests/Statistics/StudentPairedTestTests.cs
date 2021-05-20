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
    public class StudentPairedTestTests
    {
        private readonly StudentPairedTest _studentPairedTest = new StudentPairedTest(
            Mock.Of<IExecutionLogger>(), Mock.Of<ITranslator>()
        );

        [Theory]
        [MemberData(nameof(Data))]
        public void Calculate_WhenDataProvided_ThenShouldCalculatePValueCorrectly(double[] s1, double[] s2, double expectedPValue)
        {
            // Act
            var result = _studentPairedTest.Calculate(new InputData(s1, s2));

            // Assert
            result.ShouldBe(expectedPValue, TestConsts.Tolerance);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                new[] { 103.1, 130.4, 121.7, 122.2, 117.5, 116.1, 109.9, 131.1 ,122.7 ,104.5, 117.1, 111.2, 91.3, 120.2, 130.1, 106.5, 122.6, 94.0, 109.7, 118.6 },
                new[] { 122.5, 108.7, 131.4, 104.2, 95.9, 93.6, 127.3, 125, 82.9, 97.6, 119.4, 121.3, 122.9, 114.7, 121.3, 110.9, 91.7, 116.4, 122.3, 100.5 },
                .42943
            },
        };
    }
}
