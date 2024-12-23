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

        bool UpdateInOrder(List<int> update)
        {
            foreach (int number in update)
            {
                if (update.IndexOf(number) == update.Count - 1)
                    return true;
                if (!orders.ContainsKey(number))
                    return false;

                foreach (var nextNumber in update.Skip(update.IndexOf(number) + 1))
                {
                    if (!orders[number].Contains(nextNumber))
                        return false;
                }
            }

            return true;
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
