
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
        public static long part(List<int> input, int days)
        {
            Dictionary<int, long> groups = input.GroupBy(i => i).ToDictionary(g => g.Key, g =>  Convert.ToInt64(g.Count()));


            for (int day = 0; day < days; day++)
            {
                var next_groups = new Dictionary<int, long>();
                next_groups[8] = groups.GetValueOrDefault(0, 0);
                next_groups[7] = groups.GetValueOrDefault(8, 0);
                next_groups[6] = groups.GetValueOrDefault(7, 0) + groups.GetValueOrDefault(0, 0);
                next_groups[5] = groups.GetValueOrDefault(6, 0) ;
                next_groups[4] = groups.GetValueOrDefault(5, 0);
                next_groups[3] = groups.GetValueOrDefault(4, 0);
                next_groups[2] = groups.GetValueOrDefault(3, 0);
                next_groups[1] = groups.GetValueOrDefault(2, 0);
                next_groups[0] = groups.GetValueOrDefault(1, 0);
                // var normal_timer = List{1,2,3,4,6,}
                // for (int i = 1; i < 8; i++)
                // {
                //         next_groups[i-1] =groups.GetValueOrDefault(i,0);
                // }
                groups = next_groups;

            }


            return groups.Values.Sum();
        }

        static void Main(string[] args)
        {

            // 1:
            Debug.Assert(part(ReadFileToInt("test"), 18) == 26);
            Debug.Assert(part(ReadFileToInt("test"), 80) == 5934);

            // 2:
            Debug.Assert(part(ReadFileToInt("test"), 256) == 26984457539);
            Debug.Assert(part(ReadFileToInt("input"), 256) == 1681503251694);



        }

    }

}
