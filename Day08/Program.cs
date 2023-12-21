using System.Reflection;
using System.Text;

namespace Day08
{
    public class Program
    {
        static void Main(string[] args)
        {
            var test = new NonStatic();
            Console.WriteLine("Part 1: " + test.ProcessInput("input.txt"));
            var part2 = new Part2();
            Console.WriteLine("Part 2: " + part2.ProcessInput("input.txt"));
        }
    }
}