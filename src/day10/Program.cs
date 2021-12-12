
using System.Diagnostics;

namespace Aoc
{
    class Day10
    {
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

        private static readonly Dictionary<string, int> Points2
            = new Dictionary<string, int>
        {
           {")", 1},
           {"]", 2},
           {"}", 3},
           {">", 4}

        };

            static bool ValidChunkClosed(List<string> open, string chr)
            {
                return chr == StartStop.GetValueOrDefault(open.LastOrDefault(""), "");
            }

            static bool ValidChunkBegins(string chr)
            {
                return StartStop.Keys.Contains(chr);
            }

        public static string CheckChunks(List<string> open, List<string> row)
        {
            var next = 0;
            var i = 0;
            var chr = row[i];

            if (ValidChunkClosed(open, chr))
            {
                next = i + 1;
                open.RemoveAt(open.Count() - 1);
            }
            else if (ValidChunkBegins(chr))
            {
                next = i + 1;
                open.Add(row[i]);
            }
            else
            {
                // Corrupt chunk - Contains stop char for another start
                return chr;
            }
            if (row.Count() <= 1)
            {
                return "";
            }
            return CheckChunks(open, row.Skip(next).ToList());



        }
        public static int Part1(List<List<string>> input)
        {
            var results = new List<string>();
            foreach (var row in input)
            {
                var open = new List<string>();
                results.Add($"{CheckChunks(open, row)}");
            }
            var score = results.Where(x => x != "").Select(x => Points[x]).Sum();
            return score;
        }


        public static long GetScore2(List<string> open)
        {

            var closing = open.Select(chr => StartStop[chr]).Reverse();
            var score = 0L;
            foreach (string close in closing)
            {
                score = 5 * score + Points2[close];
            }
            return score;
        }

        public static List<List<string>> GetParsedInput(string name)
        {
            return File.ReadAllLines($"input/{name}.txt").Select(x => x.ToList().Select(chr => chr.ToString()).ToList()).ToList();
        }

        public static long Part2(List<List<string>> input)
        {
            var scores = new List<long>();
            foreach (var row in input)
            {
                var open = new List<string>();
                if (CheckChunks(open, row) == "")
                {
                    scores.Add(GetScore2(open));
                }
            }
            scores.Sort();
            var score = scores[scores.Count() / 2];


            return score;
        }




        static void Main(string[] args)
        {

            Debug.Assert(Part1(GetParsedInput("test")) == 26397);
            Debug.Assert(Part1(GetParsedInput("input")) == 294195);

            Debug.Assert(Part2(GetParsedInput("test")) == 288957);
            Debug.Assert(Part2(GetParsedInput("input")) == 3490802734);
        }
    }
}
