
using System.Diagnostics;
namespace Aoc
{
    class Day8
    {

        // public static List<int> ReadFileToInt(string name)
        // {
        //     var res = File.ReadAllText($"input/{name}.txt").Split("\r\n").Select(row=> row.Split(" | " ).Select(group=>group.Split(" ")));
        //     // var res2 = res.Select(x=>
        //     //     new Tuple<string,string>(x[0], x[1]);
        //     return new List<int> {1,2};
        // }
        public static long part1(string name)
        {

            var segments = new Dictionary<int,string> ();
     
            segments.Add(0, "abcefg");
            segments.Add(1, "cf");
            segments.Add(2, "acdeg");
            segments.Add(3, "acdfg");
            segments.Add(4, "bcdf");
            segments.Add(5, "abdfg");
            segments.Add(6, "abdefg");
            segments.Add(7, "acf");
            segments.Add(8, "abcdefg");
            segments.Add(9, "abcdfg");


            var segment_part_count = new Dictionary<int,int> ();

            foreach (var key in segments.Keys)
            {
                segment_part_count[key] = segments[key].Count();
            }

            var signals = File.ReadAllText($"input/{name}.txt").Split("\r\n").Select(row=>
                row.Split(" | " ).Select(group=>
                    group.Split(" ").ToList()).ToList()).ToList();

            var signals_count = signals.Select(signal=>signal[1]).Select(output_group=>
                    output_group.Select(code=>
                        code.Count()).ToList()).ToList();

            var wanted_lengths = new List<int> {2,4,3,7 };
            var counter = 0;

            foreach (var outputs in signals_count)
            {
                foreach (var output in outputs)
                {
                    if (wanted_lengths.Contains(output)){
                        counter++;
                    }
                }   
            }


            // var length_1478 = signals.Select(x=> x[1]).;
            // var count_1478 = signals.Select(x=> x[1]).;
            // Dictionary<int, long> groups = input.GroupBy(i => i).ToDictionary(g => g.Key, g =>  Convert.ToInt64(g.Count()));




            return counter;
        }

        static void Main(string[] args)
        {

       

            // 1:
            Debug.Assert(part1("test") == 26);
            Debug.Assert(part1("input") == 5934);
            Debug.Assert(part1("input") == 372984);

            // 2:
            // Debug.Assert(part(ReadFileToInt("test"), 256) == 26984457539);
            // Debug.Assert(part(ReadFileToInt("input"), 256) == 1681503251694);
        }
    }
}
