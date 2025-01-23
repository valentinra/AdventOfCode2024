using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.day0X
{
    public class DayX
    {
        public void GetPart1Result(string? input = null)
        {
            ParseInput(input ?? File.ReadAllText("..\\..\\..\\day0X\\input.txt"));
        }

        public void GetPart2Result(string? input = null)
        {

        }

        public void ParseInput(string input)
        {
            Console.WriteLine("Parsing input");
        }
    }
}
