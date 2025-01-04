using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.day06
{
    public enum eDir
    {
        UP, RIGHT, DOWN, LEFT
    }

    public struct Position
    {
        public int x;
        public int y;
        public eDir Direction;

        public void TurnRight()
        {
            if (Direction == eDir.LEFT)
                Direction = eDir.UP;
            else
                Direction++;
        }

        public class CoordinatesComparer : IEqualityComparer<Position>
        {
            public bool Equals(Position x, Position y)
            {
                return x.x == y.x && x.y == y.y;
            }

            public int GetHashCode([DisallowNull] Position obj)
            {
                return obj.x;
            }
        }
    }

    public class Day6
    {
        int countRows = 0, countColumns = 0;

        char[,] mat;

        public Position Guard;

        public int GetPart1Result(string? input = null, bool parseInput = true)
        {
            return GetVisited(input, parseInput)?.Distinct(new Position.CoordinatesComparer()).Count() ?? -1;
        }

        public List<Position>? GetVisited(string? input = null, bool parseInput = true)
        {
            if (parseInput)
                ParseInput(input ?? File.ReadAllText("..\\..\\..\\day06\\input.txt"));

            var visited = new List<Position>();

            while (InBounds(Guard.x, Guard.y))
            {
                if (visited.Any(x => x.x == Guard.x && x.y == Guard.y && x.Direction == Guard.Direction)) // the guardian enters an infinite loop
                {
                    return null;
                }
                visited.Add(Guard);
                if (Guard.Direction == eDir.UP)
                {
                    if (!InBounds(Guard.x - 1, Guard.y))
                        break;
                    if (mat[Guard.x - 1, Guard.y] != '#')
                    {
                        Guard.x--;
                    }
                    else
                        Guard.TurnRight();
                }
                else if (Guard.Direction == eDir.DOWN)
                {
                    if (!InBounds(Guard.x + 1, Guard.y))
                        break;
                    if (mat[Guard.x + 1, Guard.y] != '#')
                    {
                        Guard.x++;
                    }
                    else
                        Guard.TurnRight();
                }
                else if (Guard.Direction == eDir.LEFT)
                {
                    if (!InBounds(Guard.x, Guard.y - 1))
                        break;
                    if (mat[Guard.x, Guard.y - 1] != '#')
                    {
                        Guard.y--;
                    }
                    else
                        Guard.TurnRight();
                }
                else if (Guard.Direction == eDir.RIGHT)
                {
                    if (!InBounds(Guard.x, Guard.y + 1))
                        break;
                    if (mat[Guard.x, Guard.y + 1] != '#')
                    {
                        Guard.y++;
                    }
                    else
                        Guard.TurnRight();
                }
            }

            return visited;
        }

        bool InBounds(int x, int y)
        {
            if (x < 0 || y < 0 || x >= countRows || y >= countColumns)
                return false;

            return true;
        }

        public int GetPart2Result(string? input = null)
        {
            var watch = Stopwatch.StartNew();

            ParseInput(input ?? File.ReadAllText("..\\..\\..\\day06\\input.txt"));

            var originalGuard = Guard;

            var visited = GetVisited(input, false);
            Guard = originalGuard;

            var result = 0;

            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    if (!visited.Any(pos => pos.x == i && pos.y == j))
                        continue;

                    var isFrontOfGuardian = i == Guard.x - 1 && j == Guard.y;
                    if (!isFrontOfGuardian && (mat[i, j] == '.' || mat[i, j] == '^'))
                    {
                        mat[i, j] = '#';
                        if (GetVisited(input, false) == null) // the guardian is in a loop
                        {
                            //Console.WriteLine($"You can create a guardian infinite loop with block at: {i}/{j}");
                            result++;
                        }
                        mat[i, j] = '.';

                        Guard = originalGuard;
                    }
                }
            }

            watch.Stop();
            Console.WriteLine("Part2Result elapsed seconds: " + watch.Elapsed.TotalSeconds);
            return result;
        }

        public void ParseInput(string input)
        {
            Console.WriteLine("Parsed input");

            countColumns = input.IndexOf(Environment.NewLine);

            var lines = input.Split(Environment.NewLine);
            countRows = lines.Length;

            mat = new char[countRows, countColumns];
            Guard = new();

            int row = 0;
            foreach (var line in lines)
            {
                for (int j = 0; j < line.Length; j++)
                {
                    mat[row, j] = line[j];

                    if (mat[row, j] == '^')
                    {
                        Guard!.x = row;
                        Guard.y = j;
                        Guard.Direction = eDir.UP;
                    }
                }

                row++;
            }
        }
    }
}
