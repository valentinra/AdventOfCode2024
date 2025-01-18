using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.day07
{
    class Line
    {
        public long Left { get; set; }

        public required List<long> Values { get; set; }
    }

    public class Day7
    {
        readonly List<Line> numbersMapping = new();

        public long GetPart1Result(string? input = null, bool parseInput = true)
        {
            long result = 0;

            ParseInput(input ?? File.ReadAllText("..\\..\\..\\day07\\input.txt"));

            foreach (var line in numbersMapping)
            {
                if (IsEquationPossible(line.Values, line.Left, [(x, y) => x + y, (x, y) => x * y]))
                {
                    result += line.Left;
                }
            }

            return result;
        }

        private bool IsEquationPossible(List<long> values, long target, Func<long, long, long>[] operators)
        {
            var isPossible = false;

            if (values.Count == 1)
                return values[0] == target;

            foreach (var op in operators)
            {
                var newAddValue = op(values[0], values[1]);
                isPossible = IsEquationPossible(GetNewList(values.Skip(2), newAddValue), target, operators);
                if (isPossible)
                    return isPossible;
            }

            return false;
        }

        // get new list with elem inserted in the front
        private static List<long> GetNewList(IEnumerable<long> values, long elem)
        {
            var newList = new List<long> { elem };
            newList.AddRange(values);
            return newList;
        }

        public long GetPart2Result(string? input = null)
        {
            long result = 0;

            ParseInput(input ?? File.ReadAllText("..\\..\\..\\day07\\input.txt"));

            foreach (var line in numbersMapping)
            {
                if (IsEquationPossible(line.Values, line.Left, [(x, y) => x + y, (x, y) => x * y, (x, y) => long.Parse($"{x}{y}")]))
                {
                    result += line.Left;
                }
            }

            return result;
        }

        public void ParseInput(string input)
        {
            Console.WriteLine("Parsing input");

            var rows = input.Split(Environment.NewLine);

            foreach (var row in rows)
            {
                var line = new Line
                {
                    Left = long.Parse(row.Split(": ")[0]),

                    Values = row.Split(": ")[1].Split(' ').Select(long.Parse).ToList()
                };

                numbersMapping.Add(line);
            }
        }
    }
}
