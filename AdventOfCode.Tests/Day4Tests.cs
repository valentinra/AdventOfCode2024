using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    public class Day4Tests
    {
        [Fact]
        public void TestPart1Simple()
        {
            // Arrange
            var day4 = new Day4();
            day4.input = """
X00000000S
MMXMAS00AX
AOA0O00MOO
SOOSOOXOOO
""";

            // Act
            var result = day4.Part1();

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void TestPart1Simple2()
        {
            // Arrange
            var day4 = new Day4();
            day4.input = """
....XXMAS.
.SAMXMS...
...S..A...
..A.A.MS.X
XMASAMX.MM
X.....XA.A
S.S.S.S.SS
.A.A.A.A.A
..M.M.M.MM
.X.X.XMASX
""";
            
            // Act
            var result = day4.Part1();

            // Assert
            Assert.Equal(18, result);
        }

        [Fact]
        public void TestPart2Simple()
        {
            // Arrange
            var day4 = new Day4();
            day4.input = """
.M.S......
..A..MSMS.
.M.S.MAA..
..A.ASMSM.
.M.S.M....
..........
S.S.S.S.S.
.A.A.A.A..
M.M.M.M.M.
..........
""";

            // Act
            var result = day4.Part2();

            // Assert
            Assert.Equal(9, result);
        }
    }
}
