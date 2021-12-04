
using System.Diagnostics;
namespace Aoc
{
    class Day2
    {

        public static List<(string cmd, int step)> ReadFileToCmds(string name)
        {
            return File.ReadAllLines($"input/{name}.txt")
            .Select(x =>
                x.Split(" "))
                .Select(x =>
                    (cmd: x[0].ToString(), step: int.Parse(x[1]))).ToList();
        }
        public static (int Up ,int Forward) part1(string input_name)
        {
            var cmds = ReadFileToCmds(input_name);

            var up = 0;
            var forward = 0;
            foreach (var cmd in cmds)
            {
                switch (cmd.Item1)
                {
                    case "forward":
                        forward += cmd.Item2;

                        break;
                    case "down":
                        up += cmd.Item2;

                        break;
                    case "up":
                        up -= cmd.Item2;

                        break;

                    default:
                        break;

                }

            }
            return  (Up: up, Forward: forward);
        }

        public static int part2(List<int> input)
        {
            return input.Where((x, i) => i > 1 && i < input.Count() - 1 && input.Skip(i - 2).Take(3).Sum() < input.Skip(i - 1).Take(3).Sum()).ToList().Count();
        }
        static void Main(string[] args)
        {
            var p1_test = part1("test");
            Debug.Assert(p1_test.Up*p1_test.Forward == 150);


            var p1 = part1("input");
            Debug.Assert(p1.Up*p1.Forward == 1693300);


            // var part1_result = part1(ReadFileToCmds("input"));
            // Console.WriteLine(part1_result); // 1602

            // Debug.Assert(part2(ReadFileToCmds("test")) == 5);

            // var part2_result = part2(ReadFileToCmds("input"));
            // Console.WriteLine(part2_result); // 1633

            // Debug.Assert(part2(ReadFileToCmds("input")) == 1633);


        }

    }

}
