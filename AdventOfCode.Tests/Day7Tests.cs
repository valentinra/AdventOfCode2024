using AdventOfCode.day07;
using Xunit.Abstractions;

namespace AdventOfCode.Tests
{
    public class Day7Tests
    {
        private readonly ITestOutputHelper _output;

        public Day7Tests(ITestOutputHelper output)
        {
            _output = output;
            // Redirect console output to the test output Console.SetOut(new ConsoleOutputHelper(output));
            Console.SetOut(new ConsoleOutputHelper(output));
        }

        readonly string input = """
                190: 10 19
                3267: 81 40 27
                83: 17 5
                156: 15 6
                7290: 6 8 6 15
                161011: 16 10 13
                192: 17 8 14
                21037: 9 7 18 13
                292: 11 6 16 20
                """;

        [Fact]
        public void TestPart1()
        {
            // Arrange
            var Day7 = new Day7();

            // Act
            var result = Day7.GetPart1Result(input);

            // Assert
            Assert.Equal(3749, result);
        }

        [Fact]
        public void TestPart2()
        {
            // Arrange
            var Day7 = new Day7();

            // Act
            var result = Day7.GetPart2Result(input);

            // Assert
            Assert.Equal(6, result);
        }
    }
}
