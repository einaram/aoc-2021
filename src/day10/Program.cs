
using System.Diagnostics;

namespace Aoc
{
    class Day10
    {
        // public List<string> corrupt =new List<string>();

        private static readonly Dictionary<char, char> StartStop
            = new Dictionary<char, char>
        {
           {'(', ')'},
           {'[', ']'},
           {'{', '}'},
           {'<', '>'}

        };

        private static readonly Dictionary<char, int> Points
            = new Dictionary<char, int>
        {
           {')', 3},
           {']', 57},
           {'}', 1197},
           {'>', 25137}

        };

        public static string CheckChunk(List<string> results, string row){
            var start = row[0];
            var last = "";
            if (row.Count() <=1){
                return start.ToString();
            }
            for (int i = 1; i < row.Length; i++)
            {
                if(row[i] == StartStop.GetValueOrDefault(start,'\0')){
                    // Valid chunk, go to next
                    last = CheckChunk(results, row.Substring(i+1));
                    if (last == StartStop.GetValueOrDefault(start,'\0').ToString()){
                        return "";
                    }
                    else{
                        return last;
                    }
                    }
                else if (StartStop.Values.Contains(row[i])){
                    // Corrupt chunk
                    return row[i].ToString();

                }
                else if (StartStop.Keys.Contains(row[i]))
                //Another chunk
                {
                    results.Add(CheckChunk(results, row.Substring(i)));
                }
                var corrupt =results.Where(x=>x !="").ToList();
                if (corrupt.Count() > 0){
                    return corrupt[0];
                }
            }
            return "";
        }
        public static int Part1(string name)
        {
            // var path = $"C:/Users/einar/source/repos/aoc-2021/src/day10/input/{name}.txt";
            var res = File.ReadAllLines($"C:/Users/einar/source/repos/aoc-2021/src/day10/input/{name}.txt").ToList();


            //res.Where(row=>ValidRow(row));

            //ValidChunk()
            List<string> results =new List<string>();
            foreach (var row in res)
            {
            results.Add(CheckChunk(results, row));
                
            }
            // var row = "{([(<{}[<>[]}>{[]{[(<()>";
            // for (int i = 0; i < row.Length; i++)
            // {
            // }



            return 1;
        }



        // public static long Part1(List<int> input, int days)
        // {
        //     Dictionary<int, long> groups = input.GroupBy(i => i).ToDictionary(g => g.Key, g => Convert.ToInt64(g.Count()));



        //     return groups.Values.Sum();
        // }

        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            var map_test = Part1("test");
            var map1 = Part1("input");
            // 1:
            //     Debug.Assert(part(ReadFileToInt("test"), 18) == 26);
            //     Debug.Assert(part(ReadFileToInt("test"), 80) == 5934);
            //     Debug.Assert(part(ReadFileToInt("input"), 80) == 372984);

            //     // 2:
            //     Debug.Assert(part(ReadFileToInt("test"), 256) == 26984457539);
            //     Debug.Assert(part(ReadFileToInt("input"), 256) == 1681503251694);
        }
    }
}
