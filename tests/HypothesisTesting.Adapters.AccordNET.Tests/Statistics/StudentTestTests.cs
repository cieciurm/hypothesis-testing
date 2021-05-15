using HypothesisTesting.Adapters.AccordNET.Statistics;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using Moq;
using Shouldly;
using Xunit;

namespace HypothesisTesting.Adapters.AccordNET.Tests.Statistics
{
    public class StudentTestTests
    {
        private readonly StudentTest _studentTest = new StudentTest(Mock.Of<IExecutionLogger>(), Mock.Of<ITranslator>());

        [Fact]
        public void Calculate_WhenRealDataProvided_ThenShouldCalculatePValue()
        {
            // Arrange
            var s1 = new[] { 0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17 };
            var s2 = new[] { 1.36, 0.63, 4.79, -1.59, 2.72, -1.65, -0.58, 0.76, -2.26, 2.28, -0.19, 2.94, 0.56, -2.97, -2.03, 2.35, -0.25, 1.69, 0.62, 4.2 };
            var inputData = new InputData(s1, s2);

            // Act
            var pVal = _studentTest.Calculate(inputData, false);

            // Assert
            pVal.ShouldBeInRange(0.49, 0.50);
        }
    }
}
