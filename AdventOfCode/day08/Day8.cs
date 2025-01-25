using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.day08
{
    public struct Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is Position position && X == position.X && Y == position.Y;
        }

        public override int GetHashCode()
        {
            return X + Y;
        }
    }

    public class Day8
    {
        char[,] mat;

        int noRows, noCols = 0;

        public int GetPart1Result(string? input = null)
        {
            ParseInput(input ?? File.ReadAllText("..\\..\\..\\day08\\input.txt"));
            var antis = GetAllAntiNodes(GetAntinodesFromAntennas1);

            return antis.Distinct().Count();
        }

        private List<Position> GetAllAntiNodes(Func<Position, Position, List<Position>> antinodesFromAntennas)
        {
            var antis = new List<Position>();

            char current = '.';
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    current = mat[i, j];
                    if (current != '.')
                    {
                        var startPosition = new Position(i, j);
                        while (true)
                        {
                            var pairPosition = FindPositionOf(current, startPosition);
                            if (pairPosition.X == -1)
                                break;

                            var antiNodes = antinodesFromAntennas(new Position(i, j), pairPosition);
                            foreach (var antiNode in antiNodes)
                            {
                                if (IsNodeValid(antiNode))
                                {
                                    antis.Add(antiNode);
                                }
                            }

                            startPosition = pairPosition;
                        }
                    }
                }
            }

            return antis;
        }

        bool IsNodeValid(Position node)
        {
            return node.X >= 0 && node.X < mat.GetLength(0) && node.Y >= 0 && node.Y < mat.GetLength(1);
        }

        /// <summary>
        /// Searches for the first occurence of elem in the matrix mat starting (but ignoring) from startPosition.
        /// </summary>
        public Position FindPositionOf<T>(T elem, Position startPosition)
        {
            if (startPosition.X < 0 || startPosition.Y < 0)
                throw new ArgumentOutOfRangeException("Start position < 0");
            if (startPosition.X >= mat.GetLength(0) || startPosition.Y >= mat.GetLength(1))
                throw new ArgumentOutOfRangeException("Start position out of range");

            for (int j = startPosition.Y + 1; j < mat.GetLength(1); j++)
            {
                if (mat[startPosition.X, j].Equals(elem))
                    return new Position(startPosition.X, j);
            }

            for (int i = startPosition.X + 1; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j].Equals(elem))
                        return new Position(i, j);
                }
            }

            return new Position(-1, -1);
        }

        public int GetPart2Result(string? input = null)
        {
            ParseInput(input ?? File.ReadAllText("..\\..\\..\\day08\\input.txt"));
            var antis = GetAllAntiNodes(GetAntinodesFromAntennas2);

            return antis.Distinct().Count();
        }

        public void ParseInput(string input)
        {
            Console.WriteLine("Parsing input");

            var lines = input.Split(Environment.NewLine);
            noRows = lines.Length;
            noCols = lines[0].Length;
            Console.WriteLine($"Parsed input. noRows = {noRows}, noCols={noCols}");

            mat = new char[noRows, noCols];

            int i = 0;
            foreach (var line in lines)
            {
                int j = 0;
                foreach (var c in line)
                {
                    mat[i, j] = c;
                    j++;
                }
                i++;
            }

            Console.WriteLine($"Parsed matrix. 1st dim = {mat.GetLength(0)}, 2nd dim={mat.GetLength(1)}");
        }

        static List<Position> GetAntinodesFromAntennas1(Position antenna1, Position antenna2)
        {
            Position antinode1;
            Position antinode2;

            var diffX = antenna1.X - antenna2.X;
            var diffY = antenna1.Y - antenna2.Y;

            antinode1 = new Position(antenna1.X + diffX, antenna1.Y + diffY);
            antinode2 = new Position(antenna2.X - diffX, antenna2.Y - diffY);

            return [antinode1, antinode2];
        }

        List<Position> GetAntinodesFromAntennas2(Position antenna1, Position antenna2)
        {
            var antiNodes = new List<Position>();
            var diffX = antenna1.X - antenna2.X;
            var diffY = antenna1.Y - antenna2.Y;

            var current = antenna1;
            while(IsNodeValid(current))
            {
                antiNodes.Add(current);
                current = new Position(current.X + diffX, current.Y + diffY);
            }
            current = antenna2;
            while (IsNodeValid(current))
            {
                antiNodes.Add(current);
                current = new Position(current.X - diffX, current.Y - diffY);
            }

            return antiNodes;
        }
    }
}
