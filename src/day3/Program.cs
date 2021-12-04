
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace Aoc
{
    class Day3
    {

        public static List<string> ReadFileToStr(string name)
        {
            return File.ReadAllLines($"input/{name}.txt").ToList();
        }
        public static (List<int>, List<int>) GetZeroOneCount(List<string> input)
        {
            var ones = new List<int>(new int[input[0].Length]);
            var zeros = new List<int>(new int[input[0].Length]);
            foreach (var row in input)
            {
                var i = 0;
                foreach (var pos_val in row)
                {
                    var value = int.Parse(pos_val.ToString());
                    if (value == 1)
                    {
                        ones[i]++;

                    }
                    else
                    {
                        zeros[i]++;
                    }
                    i++;

                }
            }
            return (zeros, ones);
        }
        public static List<int> GetMostCommonForEach(List<string> input)
        {
            var (zeros, ones) = GetZeroOneCount(input);

            var zero_or_one = new List<int>();
            foreach (var x in ones)
            {
                if (2 * x >= input.Count)
                {
                    zero_or_one.Add(1);

                }
                else
                {
                    zero_or_one.Add(0);
                }
            }

            return zero_or_one;
        }

        public static int GetMostCommon(List<string> input, int i)
        {
            var (zeros, ones) = GetZeroOneCount(input);

            var x = ones[i];
            if (2 * x >= input.Count)
            {
                return 1;

            }
            else
            {
                return 0;
            }
        }


        public static int GetLeastCommon(List<string> input, int i)
        {
            var (zeros, ones) = GetZeroOneCount(input);

            if (2 * ones[i] < input.Count)
            {
                return 1;

            }
            else
            {
                return 0;
            }

        }
        public static long part1(List<string> input)
        {
            var gamma = GetMostCommonForEach(input);

            var epsilon = gamma.Select(x => 1 - x);

            var a = Convert.ToInt64(string.Join("", gamma), 2);
            var b = Convert.ToInt64(string.Join("", epsilon), 2);

            return a * b;
        }


        public static string GetLastMost(List<string> input)
        {

            string last_number = "";
            var input_tmp = input.ToList();

            for (int i = 0; i < input[0].Count(); i++)
            {
                var keeper = GetMostCommon(input_tmp, i);
                last_number += keeper.ToString(); //Hva skjer?!

                foreach (var number in input_tmp.ToList())  //copy the list every iteration to allow "remove" in foreach 
                {
                    if (input_tmp.Count() == 1)
                    {
                        return number;
                    }
                    if (int.Parse(number[i].ToString()) != keeper)
                    {
                        input_tmp.Remove(number);
                    }

                }
            }
            return last_number;
        }

        public static string GetLastLeast(List<string> input)
        {

            string last_number = "";
            var input_tmp = input.ToList();

            for (int i = 0; i < input[0].Count(); i++)
            {
                var keeper = GetLeastCommon(input_tmp, i);
                last_number += keeper.ToString();

                foreach (var number in input_tmp.ToList())  //copy the list every iteration to allow "remove" in foreach 
                {
                    if (input_tmp.Count() == 1)
                    {
                        return number;
                    }
                    if (int.Parse(number[i].ToString()) != keeper)
                    {
                        input_tmp.Remove(number);

                    }

                }
            }
            return last_number;
        }

        public static long part2(List<string> input)
        {
            var oxy_b = GetLastMost(input);
            var co2_b = GetLastLeast(input);
            var oxy = Convert.ToInt64(oxy_b, 2);
            var co2 = Convert.ToInt64(co2_b, 2);

            return oxy * co2;
        }
        static void Main(string[] args)
        {

            Debug.Assert(part1(ReadFileToStr("test")) == 198);
            Debug.Assert(part1(ReadFileToStr("input")) == 3895776);

            Debug.Assert(part2(ReadFileToStr("test")) == 230);

            var part2_result = part2(ReadFileToStr("input"));
            Debug.Assert(part2_result == 7928162);

            Console.WriteLine(part2_result);



        }

    }

}
