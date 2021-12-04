
using System.Diagnostics;
namespace Aoc
{
    class Day4
    {

        public static bool ListIsBingo(List<int> line){
            if (line.All(x=> x == -1)){
                    return true;
                }    
            else
            {
                return false;
            }
        }

        public static bool BoardIsBingo(List<List<int>> board){
   
                // Check row:
                if (board.Where(line=> ListIsBingo(line)).Count() > 0){
                    return true;
                }
            
                // Check column:
                for (int i = 0; i < board[0].Count; i++)
                {
                    var col = board.Select(line => line[i]).ToList();
                    if (ListIsBingo(col)){
                        return true;
                    }
                }              

            return false;
        }


        public static (List<List<List<int>>>, List<int>) GetGame(string name)
        {
            var inputfile = $"input/{name}.txt";
            var reader = new StreamReader(inputfile);

            var numbers = new string(reader.ReadLine()).Split(",").Select(x => int.Parse(x)).ToList();

            var lines = reader.ReadToEnd().Trim();

            var raw_boards = lines.Split("\r\n\r\n");

            var boards = new List<List<List<int>>>();
            foreach (var raw_board in raw_boards)
            {
                var board_lines = raw_board.Split("\r\n");
                var board_str = board_lines.Select(x =>
                    System.Text.RegularExpressions.Regex.Split(x.Trim(), @"\s+")
                );

                var board = board_str.Select(row =>
                    row.Select(x => int.Parse(x)).ToList()
                    ).ToList();

                boards.Add(board);

            }
            return (boards, numbers);
        }
        public static int part1(string name)
        {
            var (boards, numbers) = GetGame(name);


            foreach (var number in numbers)
            {
                foreach (var board in boards.ToList())
                {
                    foreach (var line in board)
                    {
                        for (int i = 0; i < line.Count; i++)
                        {
                            if (line[i] == number)
                            {
                                line[i] = -1;
                            }
                        }

                    }
                    if (BoardIsBingo(board) == true){
                        var board_sum = board.SelectMany(x=>x).Where(x=>x!=-1).Sum();
                        Console.WriteLine($"Bingo, {number}. Sum{board_sum}. {number*board_sum}");
                        return number*board_sum;
                    }

                }

            }
            return 1;
        }

        public static int? part2(string name)
        {
            var (boards, numbers) = GetGame(name);

            foreach (var number in numbers)
            {
                foreach (var board in boards.ToList())
                {
                    foreach (var line in board)
                    {
                        for (int i = 0; i < line.Count; i++)
                        {
                            if (line[i] == number)
                            {
                                line[i] = -1;
                            }
                        }

                    }

                    if (BoardIsBingo(board) == true){
                        if (boards.Count ==1  )
                        {
                            var board_sum = board.SelectMany(x=>x).Where(x=>x!=-1).Sum();
                            Console.WriteLine($"Bingo, {number}. Sum{board_sum}. {number*board_sum}");
                            return number*board_sum;

                        }
                        else
                        {
                            boards.Remove(board);
                        }
                    }

                }

            }
            return null;
        }
        static void Main(string[] args)
        {

            Debug.Assert(part1("test") == 4512);
            Debug.Assert(part1("input") == 4662);
            Debug.Assert(part2("test") == 1924);
            Debug.Assert(part2("input") == 12080);

        }

    }

}
