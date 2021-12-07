
using System.Diagnostics;
namespace Aoc
{
    class Day1
    {

        public static List<int> ReadFileToInt(string name)
        {
            var res = File.ReadAllText($"input/{name}.txt").Split(",").Select(int.Parse).ToList();
            return res;
        }
        public static long part1(List<int> input)
        {
            Dictionary<int, long> groups = input.GroupBy(i => i).ToDictionary(g => g.Key, g =>  Convert.ToInt64(g.Count()));
            input.Sort();
            var median = input[input.Count / 2];
            var cost_sum =0L;
            foreach (var key in groups.Keys)
            {

                var cost = Math.Abs(key-median)* groups[key] ;
                cost_sum += cost;
            }

            return cost_sum;
        }
        public static long part2(List<int> input)
        {
            Dictionary<int, long> groups = input.GroupBy(i => i).ToDictionary(g => g.Key, g => Convert.ToInt64(g.Count()));

            var avg = Convert.ToInt64(input.Sum()/input.Count());
            var cost_sum = 0L;
            foreach (var key in groups.Keys)
            {
                int dx =  Convert.ToInt32(Math.Abs(key - avg));
                var cost_each = Enumerable.Range(1, dx).Select(i => i).Sum();
                var cost = cost_each  *groups[key];
                cost_sum += cost;
            }

            return cost_sum;
        }
        static void Main(string[] args)
        {

            // 1:
            Debug.Assert(part1(ReadFileToInt("test")) == 37);
            Debug.Assert(part1(ReadFileToInt("input")) == 349357);

            // 2:
            // Debug.Assert(part2(ReadFileToInt("test")) == 168); // Only valid if date is 
            Debug.Assert(part2(ReadFileToInt("input")) == 96708205);

        }
    }
}
