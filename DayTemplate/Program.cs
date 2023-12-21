using System.Reflection;
using System.Text;

namespace DayTemplate
{
    public class Program
    {
        static void Main(string[] args)
        {
            var run = new Part1();
            int actualOutput = run.ProcessInput("input.txt");
            Console.WriteLine("Part 1: " + actualOutput);
        }
    }
}