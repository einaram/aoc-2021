
var input = File.ReadAllLines("../../input/1input.txt").Select(int.Parse).ToList();
// var input = File.ReadAllLines("/home/azureuser/aoc/1test.txt").Select(int.Parse).ToList();

var part1 = input.Where((x,i) => i > 0 && input[i-1] < x ).Count();
Console.WriteLine(part1);

var part2 = input.Where((x, i) => i>1 && i< input.Count()-1 && input.Skip(i-2).Take(3).Sum() < input.Skip(i-1 ).Take(3).Sum()).ToList().Count();
Console.WriteLine(part2);
