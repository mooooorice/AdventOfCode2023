using System.Reflection;
using System.Text;

namespace Day09
{
    public class Program
    {
        static void Main(string[] args)
        {
            var run = new Part1And2();
            Console.WriteLine("Part 1: " + run.ProcessInput(Part1And2.sumFunctionEnd, "input.txt"));
            Console.WriteLine("Part 2: " + run.ProcessInput(Part1And2.sumFunctionBeginning, "input.txt"));
        }
    }
}