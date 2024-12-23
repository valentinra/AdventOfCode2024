using AdventOfCode.day05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    public class Day5Tests
    {
        [Fact]
        public void TestPart1Simple()
        {
            // Arrange
            var input = """
                47|53
                97|13
                97|61
                97|47
                75|29
                61|13
                75|53
                29|13
                97|29
                53|29
                61|53
                97|53
                61|29
                47|13
                75|47
                97|75
                47|61
                75|61
                47|29
                75|13
                53|13

                75,47,61,53,29
                97,61,53,29,13
                75,29,13
                75,97,47,61,53
                61,13,29
                97,13,75,29,47
                """;

            var day5 = new Day5();

            // Act
            var result = day5.GetPart1Result(input);

            // Assert
            Assert.Equal(143, result);
        }
    }
}
