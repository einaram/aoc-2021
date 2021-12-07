
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
        public static long part(List<int> input)
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

        static void Main(string[] args)
        {

            // 1:
            Debug.Assert(part(ReadFileToInt("test")) == 37);
            Debug.Assert(part(ReadFileToInt("input")) == 349357);

            // 2:
            Debug.Assert(part(ReadFileToInt("test")) == 26984457539);
            Debug.Assert(part(ReadFileToInt("input")) == 1681503251694);
        }
    }
}
