
using System.Diagnostics;
namespace Aoc
{

    public struct Coord
    // Hello useless struct
    {
        public int x;
        public int y;
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
        public Coord(List<int> coord)
        {
            this.x = coord[0];
            this.y = coord[1];

        }
        public static Coord operator -(Coord c1, Coord c2)
        {
            var x = c1.x - c2.x;
            var y = c1.y - c2.y;

            return new Coord(x, y);
        }

        public static Coord operator +(Coord c1, Coord c2)
        {
            var x = c1.x + c2.x;
            var y = c1.y + c2.y;

            return new Coord(x, y);
        }

        public static Coord operator /(Coord c1, Coord c2)
        {
            var x = c1.x / c2.x;
            var y = c1.y / c2.y;

            return new Coord(x, y);
        }
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }

    class Day1
    {

        public static List<List<List<int>>> ReadFileToCoords(string name)
        {
            var raw_input = File.ReadAllLines($"input/{name}.txt");

            var raw_coords = raw_input.Select(row =>
                row.Split("->")
                    .Select(xy => xy.Trim().Split(",")
                        .Select(part => int.Parse(part)).ToList()

                    ).ToList()

                    ).ToList();

            return raw_coords;
        }
        public static int get_step(int delta)
        {
            var step = 0;
            if (delta != 0)
            {
                step = Math.Abs(delta) / delta;
            }
            return step;
        }

        public static int part(List<List<List<int>>> line_coords, bool diagonal)
        {
            var grid = new Dictionary<Coord, int>();
            foreach (var coords in line_coords)
            {
                var start = new Coord(coords[0]);
                var stop = new Coord(coords[1]);

                if (start.x != stop.x && start.y != stop.y && !diagonal)
                {
                    continue;
                }

                var dx = stop.x - start.x;
                var dy = stop.y - start.y;
                var x_step = get_step(dx);
                var y_step = get_step(dy);

                var max = Math.Max(Math.Abs(dy), Math.Abs(dx));
                for (int i = 0; i <= max; i++)
                {
                    var coord = new Coord(start.x + i * x_step, start.y + i * y_step);
                    if (!grid.TryAdd(coord, 1))
                    {
                        grid[coord] += 1;
                    }
                }
            }

            return grid.Values.Where(x => x > 1).Count();

        }

        static void Main(string[] args)
        {
            Debug.Assert(part(ReadFileToCoords("test"), false) == 5);
            Debug.Assert(part(ReadFileToCoords("input"), false) == 6267);

            Debug.Assert(part(ReadFileToCoords("test"), true) == 12);
            Debug.Assert(part(ReadFileToCoords("input"), true) == 20196);




        }

    }

}
