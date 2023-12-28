using System.Reflection;
using System.Text;

namespace Day09
{
    public class Program
    {
        static void Main(string[] args)
        {
            var run = new Part1And2("input.txt");
            Console.WriteLine("Part 1: " + run.SumEnd());
            Console.WriteLine("Part 2: " + run.SumBeginning());
        }
    }
}