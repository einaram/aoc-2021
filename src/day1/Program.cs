
using System.Diagnostics;
namespace Aoc
{
    class Day1
    {

        public static List<int> ReadFileToInt(string name)
        {
            return File.ReadAllLines($"input/{name}.txt").Select(int.Parse).ToList();
        }
        public static int part1(List<int> input)
        {
            return input.Where((x, i) => i > 0 && input[i - 1] < x).Count();
        }

        public static int part2(List<int> input)
        {
            return input.Where((x, i) => i > 1 && i < input.Count() - 1 && input.Skip(i - 2).Take(3).Sum() < input.Skip(i - 1).Take(3).Sum()).ToList().Count();
        }
        static void Main(string[] args)
        {

            Debug.Assert(part1(ReadFileToInt("test")) == 7);

            var part1_result = part1(ReadFileToInt("input"));
            Console.WriteLine(part1_result); // 1602

            Debug.Assert(part2(ReadFileToInt("test")) == 5);

            var part2_result = part2(ReadFileToInt("input"));
            Console.WriteLine(part2_result); // 1633

            Debug.Assert(part2(ReadFileToInt("input")) == 1633);


        }

    }

}
