using AdventOfCode.day05;
using AdventOfCode.day06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AdventOfCode.Tests
{
    public class Day6Tests
    {
        private readonly ITestOutputHelper _output;

        public Day6Tests(ITestOutputHelper output)
        {
            _output = output;
            // Redirect console output to the test output Console.SetOut(new ConsoleOutputHelper(output));
            Console.SetOut(new ConsoleOutputHelper(output));
        }

        string input = """
                ....#.....
                .........#
                ..........
                ..#.......
                .......#..
                ..........
                .#..^.....
                ........#.
                #.........
                ......#...
                """;

        [Fact]
        public void TestPart1()
        {
            // Arrange
            var day6 = new Day6();

            // Act
            var result = day6.GetPart1Result(input);

            // Assert
            Assert.Equal(41, result);
        }

        [Fact]
        public void TestPart2()
        {
            // Arrange
            var day6 = new Day6();

            // Act
            var result = day6.GetPart2Result(input);

            // Assert
            Assert.Equal(6, result);
        }
    }
}
