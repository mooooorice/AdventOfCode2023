using System.Reflection;
using System.Text;

namespace Day06
{
    public class Program
    {
        static string day = "Day06";
        static void Main(string[] args)
        {
            string actualOutput = ProcessInput("input.txt");
            Console.WriteLine(AppContext.BaseDirectory);
            Console.WriteLine(actualOutput);
        }
        
        public static string ProcessInput(string inputFile)
        {
            string baseDirectory = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
            string fullFilePath = baseDirectory + "/" + day + "/Inputs/" + inputFile;
            StringBuilder output = new StringBuilder();
            const Int32 BufferSize = 128;
            
            using (var fileStream = File.OpenRead(fullFilePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()!) != null)
                {
                    // Process each line and append to output
                    output.AppendLine(line);
                }
            }
            return output.ToString().Trim();            
        }
    }
}