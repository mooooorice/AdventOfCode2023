using System.Reflection;
using System.Text;

namespace Day10ToEnd
{
    public class Program
    {
        static void Main(string[] args)
        {
            var run = new Day10();
            int actualOutput = run.ProcessInput("input.txt");
            Console.WriteLine("Part 1: " + actualOutput);
        }
    }
}