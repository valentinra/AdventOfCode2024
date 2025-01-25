using AdventOfCode.day08;
using Xunit.Abstractions;

namespace AdventOfCode.Tests
{
    public class Day8Tests
    {
        private readonly ITestOutputHelper _output;

        public Day8Tests(ITestOutputHelper output)
        {
            _output = output;
            // Redirect console output to the test output Console.SetOut(new ConsoleOutputHelper(output));
            Console.SetOut(new ConsoleOutputHelper(output));
        }

        readonly string input = """
                ............
                ........0...
                .....0......
                .......0....
                ....0.......
                ......A.....
                ............
                ............
                ........A...
                .........A..
                ............
                ............
                """;

        [Fact]
        public void TestPart1()
        {
            // Arrange
            var Day8 = new Day8();

            // Act
            var result = Day8.GetPart1Result(input);

            // Assert
            Assert.Equal(14, result);
        }

        [Fact]
        public void TestPart2()
        {
            // Arrange
            var Day8 = new Day8();

            // Act
            var result = Day8.GetPart2Result(input);

            // Assert
            Assert.Equal(34, result);
        }
    }
}
