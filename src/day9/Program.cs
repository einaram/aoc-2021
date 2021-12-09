
using System.Diagnostics;
namespace Aoc
{
    class Day1
    {

        // https://stackoverflow.com/questions/35670333/find-nearby-values-in-array_
        private static List<int> GetNearbyValues(int[][] array2D, int i, int j)
        {
            var values = from x in Enumerable.Range(i - 1, i + 1)
                         from y in Enumerable.Range(j - 1, j + 1)
                             // make sure x and y are all positive
                         where x >= 0 && y >= 0 && (x != i | y != j)
                         select array2D[x][y];
            return values.Cast<int>().ToList();
        }
        public static int[][] ReadFileToMap(string name)
        {
            var res = File.ReadAllLines($"input/{name}.txt").ToList();
            var map = new int[res.Count][];

            for (int i = 0; i < res.Count(); i++)
            {
                var row = res[i];
                  
                var row_array =row.ToList().Select(x => int.Parse(x.ToString())).ToArray() ;

                map[i] = row_array;
                
            }
            for (int i = 0; i < map.Count(); i++)
            {
                var row = map[i];
                var lowpoints = new List<int>();
                for (int j = 0; j < row.Count(); j++)
                {
                    var top = map.Skip(i-1).Take(1).Skip(i-1).Take(1).First();
                    var bottom = map.Skip(i).Take(1).Skip(i - 1).Take(1).First();
                    var left = row.Skip(i - 1).Take(1).First();
                    var right = row.Skip(i).Take(1).First();
                    // var surrounding = new List<int> {top, bottom, left, right};


                        if(row[j] < GetNearbyValues(map,i,j).Min()) {
                            lowpoints.Add(row[j]);
                    }
                }
            }

            return map;
        }
        public static long part(List<int> input, int days)
        {
            Dictionary<int, long> groups = input.GroupBy(i => i).ToDictionary(g => g.Key, g =>  Convert.ToInt64(g.Count()));



            return groups.Values.Sum();
        }

        static void Main(string[] args)
        {

            var map = ReadFileToMap("test");
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
