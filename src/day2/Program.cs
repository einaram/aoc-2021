
using System.Diagnostics;
namespace Aoc
{
    class Day2
    {

        public static List<(string Cmd, int Step)> ReadFileToCmds(string name)
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


        public static (int Depth ,int Forward) part2(string input_name)
        {
            var cmds = ReadFileToCmds(input_name);

            var depth = 0;
            var aim = 0;
            var forward = 0;
            foreach (var cmd in cmds)
            {
                switch (cmd.Item1)
                {
                    case "forward":
                        forward += cmd.Step;
                        depth += aim* cmd.Step;
                        break;
                    case "down":
                        aim += cmd.Step;
                        break;
                    case "up":
                        aim -= cmd.Step;
                        break;

                    default:
                        break;

                }

            }
            return  (Depth: depth, Forward: forward);
        }


        static void Main(string[] args)
        {
            var p1_test = part1("test");
            Debug.Assert(p1_test.Up*p1_test.Forward == 150);


            var p1 = part1("input");
            Debug.Assert(p1.Up*p1.Forward == 1693300);


            var p2_test = part2("test");
            Debug.Assert(p2_test.Depth*p2_test.Forward == 900);



            var p2 = part2("input");
            Debug.Assert(p2.Depth*p2.Forward == 1857958050);

        }

    }

}
