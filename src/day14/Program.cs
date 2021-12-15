
using System.Diagnostics;
namespace Aoc
{
    class Day14
    {

        public static Tuple<List<string>, Dictionary<string, string>> ReadFile(string inputName)
        {
            var input = File.ReadAllLines($"input/{inputName}.txt").ToList();
            List<string> template = input[0].Select(x => x.ToString()).ToList();
            input.RemoveAt(0); // template
            input.RemoveAt(0); //blank row
            var rules = new Dictionary<string, string>();

            foreach (string row in input)
            {
                var row_split = row.Split("->");
                var key = row_split[0].Trim();
                var insert = row_split[1].Trim();

                rules.Add(key, insert);
            }

            return new Tuple<List<string>, Dictionary<string, string>>(template, rules);

        }
        public static long Part(
            Tuple<List<string>, Dictionary<string, string>> input,
            int steps)
        {
            var template = input.Item1;
            var rules = input.Item2;

            var pairs = GetPairs(template, rules);

            Dictionary<string, long> pairs_count = GetNewPairs(steps, rules, pairs);

            Dictionary<char, long> letter_count_freq = CountLetters(template, pairs_count);

            long max = letter_count_freq.Values.Max() / 2;
            long min = letter_count_freq.Values.Min() / 2;

            return max - min;

        }

        private static Dictionary<char, long> CountLetters(List<string> template, Dictionary<string, long> pairs_count)
        {
            var letter_count_freq = new Dictionary<char, long>();
            foreach (var pair in pairs_count)
            {
                letter_count_freq[pair.Key[0]] = letter_count_freq.GetValueOrDefault(pair.Key[0], 0) + pair.Value;
                letter_count_freq[pair.Key[1]] = letter_count_freq.GetValueOrDefault(pair.Key[1], 0) + pair.Value;
            }

            letter_count_freq[template[0].ToCharArray()[0]] += 1;
            var last_char = template[template.Count() - 1].ToCharArray()[0];
            letter_count_freq[last_char] += 1;
            return letter_count_freq;
        }

        private static Dictionary<string, long> GetNewPairs(int steps, Dictionary<string, string> rules, List<string> pairs)
        {
            var pairs_count = pairs.GroupBy(x => x).
                ToDictionary(x => x.Key, x => x.LongCount());


            for (int i = 0; i < steps; i++)
            {
                var next_pairs_count = new Dictionary<string, long>();
                foreach (var pair in pairs_count.Keys)
                {
                    var inserted1 = pair[0].ToString() + rules[pair];
                    var inserted2 = rules[pair] + pair[1].ToString();
                    next_pairs_count[inserted1] = next_pairs_count.GetValueOrDefault(inserted1, 0) + pairs_count[pair];
                    next_pairs_count[inserted2] = next_pairs_count.GetValueOrDefault(inserted2, 0) + pairs_count[pair];

                }
                pairs_count = next_pairs_count;
            }

            return pairs_count;
        }

        private static List<string> GetPairs(List<string> template,
                                             Dictionary<string, string> rules)
        {
            var output = new List<string>();
            for (int i = 0; i < template.Count - 1; i++)
            {
                var pair = string.Join("", template.GetRange(i, 2));
                output.Add(pair);
            }
            return output;
        }

        static void Main(string[] args)
        {

            Debug.Assert(Part(ReadFile("test"), 10) == 1588);
            Debug.Assert(Part(ReadFile("input"), 10) == 2621);
            Debug.Assert(Part(ReadFile("test"), 40) == 2188189693529);
            Debug.Assert(Part(ReadFile("test"), 40) == 2843834241366);

        }
    }
}
