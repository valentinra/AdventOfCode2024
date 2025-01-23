using AdventOfCode.day0X;
using Xunit.Abstractions;

namespace AdventOfCode.Tests
{
    public class DayXTests
    {
        private readonly ITestOutputHelper _output;

        public DayXTests(ITestOutputHelper output)
        {
            _output = output;
            // Redirect console output to the test output Console.SetOut(new ConsoleOutputHelper(output));
            Console.SetOut(new ConsoleOutputHelper(output));
        }

        readonly string input = """
                
                """;

        [Fact]
        public void TestPart1()
        {
            // Arrange
            var DayX = new DayX();

            // Act
            DayX.GetPart1Result(input);

            // Assert
            //Assert.Equal(3749, result);
        }

        [Fact]
        public void TestPart2()
        {
            // Arrange
            var DayX = new DayX();

            // Act
            DayX.GetPart2Result(input);

            // Assert
            //Assert.Equal(11387, result);
        }
    }
}
