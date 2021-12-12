
using System.Diagnostics;

namespace Aoc
{
    class Day10
    {
        // public List<string> corrupt =new List<string>();

        private static readonly Dictionary<string, string> StartStop
            = new Dictionary<string, string>
        {
           {"(", ")"},
           {"[", "]"},
           {"{", "}"},
           {"<", ">"}

        };

        private static readonly Dictionary<string, int> Points
            = new Dictionary<string, int>
        {
           {")", 3},
           {"]", 57},
           {"}", 1197},
           {">", 25137}

        };

        public static string CheckChunk(List<string> open, List<string> row)
        {
            if (row.Count() <= 1){
                return "End"+ String.Join(";",row);
            }
            var start = row[0];
            var next = 0;

            var i = 1;
            Console.Write(start);
            Debug.Write(start);

            if (row[i] == StartStop.GetValueOrDefault(start, ""))
            {
                // Valid chunk closed, go to next
                next = i+1;
            }
            else if (StartStop.Values.Contains(row[i]))
            {
                // Corrupt chunk - Contatins stop char for another start
                return $"c: {row[i]}";

            }
            else if (StartStop.Keys.Contains(row[i]))
            //Another chunk begins
            {
                // return CheckChunk(results, row.Skip(i).ToList());
                next =i;

            }
            return CheckChunk(open, row.Skip(next).ToList());

            // var corrupt = results.Where(x => x != "").ToList();
            // if (corrupt.Count() > 0)
            // {
            //     return corrupt[0];
            // }
            return "";
        }
    public static int Part1(string name)
    {
        // var path = $"C:/Users/einar/source/repos/aoc-2021/src/day10/input/{name}.txt";
        var res = File.ReadAllLines($"C:/Users/einar/source/repos/aoc-2021/src/day10/input/{name}.txt").Select(x => x.ToList().Select(chr => chr.ToString()).ToList()).ToList();


        //res.Where(row=>ValidRow(row));

        //ValidChunk()
        var results = new List<string>();
        var open = new List<string>();
        foreach (var row in res)
        {   
            var rowstr = String.Join("",row);
            results.Add($"{CheckChunk(results, row)} {rowstr} ");

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
