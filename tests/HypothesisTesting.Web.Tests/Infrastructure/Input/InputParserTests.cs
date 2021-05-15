using HypothesisTesting.Web.Infrastructure.Input;
using Shouldly;
using Xunit;

namespace HypothesisTesting.Web.Tests.Infrastructure.Input
{
    public class InputParserTests
    {
        [Theory]
        [InlineData("2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 7, 8,  ", 25)]
        [InlineData("2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8  ", 29)]
        public void Parse_WhenInputProvided_ThenShouldParseCorrectly(string input, int expectedLength)
        {
            // Act
            var output = InputParser.Parse(input);

            // Assert
            output.Values.Length.ShouldBe(expectedLength);
        }
    }
}
