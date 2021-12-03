
using System.Diagnostics;
namespace Aoc
{
    class Day3
    {

        public static string[] ReadFileToStr(string name)
        {
            return File.ReadAllLines($"input/{name}.txt").ToArray();
        }
        public static long part1(string[] input)
        {

            var ones = new List<int>(new int[input[0].Length]);
            foreach (var row in input)
            {
                var i = 0;
                foreach (var pos_val in row)
                {
                    ones[i] += int.Parse(pos_val.ToString());
                    i++;

                }
            }
            var gamma = "";
            foreach (var x in ones)
            {
                if (x > input.Length / 2)
                {
                    gamma += "1";
                }
                else
                {
                    gamma += "0";

                }

            }

            var epsilon = "";
            foreach (var x in ones)
            {
                if (x < input.Length / 2)
                {
                    epsilon += "1";
                }
                else
                {
                    epsilon += "0";

                }

            }

            var a = Convert.ToInt64(gamma, 2);
            var b = Convert.ToInt64(epsilon, 2);
            return a * b;
        }

        // public static int part2 (string[] input)
        // {
            //return ..
        // }
        static void Main(string[] args)
        {

            Debug.Assert(part1(ReadFileToStr("input")) == 3895776);

            var part1_result = part1(ReadFileToStr("input"));
            Console.WriteLine(part1_result); // 

            // Debug.Assert(part2(ReadFileToStr("test")) == 5);

            // var part2_result = part2(ReadFileToStr("input"));
            // Console.WriteLine(part2_result); // 1633

            // Debug.Assert(part2(ReadFileToStr("input")) == 1633);


        }

    }

}
