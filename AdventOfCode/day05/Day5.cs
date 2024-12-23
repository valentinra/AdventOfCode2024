using AdventOfCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.day05
{
    public class Day5
    {
        public int GetPart1Result(string? input = null)
        {
            int result = 0;

            ParseInput(input ?? File.ReadAllText("..\\..\\..\\day05\\input.txt"));

            foreach (var update in updates)
            {
                if (UpdateInOrder(update))
                    result += update[update.Count / 2];
            }

            return result;
        }

        public int GetPart2Result(string? input = null)
        {
            int result = 0;

            ParseInput(input ?? File.ReadAllText("..\\..\\..\\day05\\input.txt"));

            foreach (var update in updates)
            {
                if (SortUpdate(update))
                    result += update[update.Count / 2];
            }

            return result;
        }

        bool UpdateInOrder(List<int> update)
        {
            for (int i = 0; i < update.Count; i++)
            {
                var number = update[i];
                if (i == update.Count - 1)
                    return true;
                if (!orders.ContainsKey(number))
                    return false;

                for (int j = i + 1; j < update.Count; j++)
                {
                    var nextNumber = update[j];
                    if (!orders[number].Contains(nextNumber))
                        return false;
                }
            }

            return true;
        }

        bool SortUpdate(List<int> update)
        {
            bool reordered = false;

            for (int i = 0; i < update.Count; i++)
            {
                var number = update[i];
                if (i == update.Count - 1)
                    return reordered;
                if (!orders.ContainsKey(number))
                {
                    if (!orders.ContainsKey(update[i + 1]))
                        throw new Exception("This should not happen");
                    else // probably a simpler solution would be to just move 'number' to the end
                    {
                        update[i] = update[i+1];
                        update[i+1] = number;
                        reordered = true;
                        i--;
                        continue;
                    }
                }

                for (int j = i + 1; j < update.Count; j++)
                {
                    var nextNumber = update[j];
                    
                    if (!orders[number].Contains(nextNumber))
                    {
                        update[i] = nextNumber;
                        update[j] = number;
                        reordered = true;
                        i--;
                        break;
                    }
                }
            }

            return reordered;
        }

        public void ParseInput(string input)
        {
            var lines = input.Split(Environment.NewLine);

            var ordersAreRead = false;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    ordersAreRead = true;
                    continue;
                }
                else if (!ordersAreRead)
                {
                    var order1 = int.Parse(line.Split('|')[0]);
                    var order2 = int.Parse(line.Split('|')[1]);
                    if (!orders.ContainsKey(order1))
                        orders[order1] = [order2];
                    else
                        orders[order1].Add(order2);
                }
                else
                {
                    updates.Add(line.Split(',').Select(int.Parse).ToList());
                }
            }
        }

        public Dictionary<int, List<int>> orders = [];

        public List<List<int>> updates = [];
    }
}
