using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.day08
{
    public class Day8
    {
        public int GetPart1Result(string? input = null)
        {
            int result = 0;

            ParseInput(input ?? File.ReadAllText("..\\..\\..\\day08\\input.txt"));

            return result;
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
