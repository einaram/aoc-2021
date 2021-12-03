
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
        public static List<int> GetOnes(List<string> input)
        {
            var ones = new List<int>(new int[input[0].Length]);
            foreach (var row in input)
            {
                var i = 0;
                foreach (var pos_val in row)
                {
                    var value =int.Parse(pos_val.ToString());
                    if (value == 1){
                        ones[i] ++;

                    } 
                    i++;

                }
            }
            return ones;
        }
        public static List<int> GetMostCommonForEach(List<string> input)
        {
            var ones = GetOnes(input);

            var zero_or_one = new List<int>();
            foreach (var x in ones)
            {
                if (x >= input.Count / 2)
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

        public static List<int> GetLeastCommonForEach(List<string> input)
        {
            var ones = GetOnes(input);

            var zero_or_one = new List<int>();
            foreach (var x in ones)
            {
                if (2*x < input.Count )
                {
                    zero_or_one.Add(0);

                }
                else
                {
                    zero_or_one.Add(1);
                }
            }

            return zero_or_one;
        }
        public static long part1(List<string> input)
        {

            var gamma = GetMostCommonForEach(input);


            var epsilon = gamma.Select(x => 1 - x);


            var a = Convert.ToInt64(string.Join("", gamma), 2);
            var b = Convert.ToInt64(string.Join("", epsilon), 2);

            return a * b;
        }


        public static string GetLast(List<string> input, List<int> common){
            
            string last_number="";
            var input_tmp = input.ToList();
            foreach (var (item, index) in common.Select((item, index) => (item, index)))
            {
                foreach (var number in input_tmp.ToList())  //copies the list every iteration.. 
                {
                    if (number[index].ToString() != item.ToString())
                    {
                        input_tmp.Remove(number);
                        last_number = number;
                    }

                }
            }
            return last_number;
        }
        public static long part2(List<string> input)
        {
           var most_common = GetMostCommonForEach(input);
           var least_common = GetLeastCommonForEach(input);
            var least_common2 = most_common.Select(x => 1 - x).ToList();
            

            var oxy_b = GetLast(input,most_common );
            var co2_b = GetLast(input, least_common);
            var oxy = Convert.ToInt64( oxy_b, 2);
            var co2 = Convert.ToInt64(co2_b, 2);

            return oxy * co2;
        }
        static void Main(string[] args)
        {

            // Debug.Assert(part1(ReadFileToStr("test")) == 198);
            // Debug.Assert(part1(ReadFileToStr("input")) == 3895776);

            Debug.Assert(part2(ReadFileToStr("test")) == 230);

            var part2_result = part2(ReadFileToStr("input"));
            Debug.Assert(part2_result == 7928162);

            // var part2_result = part2(ReadFileToStr("input"));
            Console.WriteLine(part2_result); 

            // Debug.Assert(part2(ReadFileToStr("input")) == 1633);


        }

    }

}
