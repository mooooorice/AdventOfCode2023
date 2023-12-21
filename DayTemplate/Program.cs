using System.Reflection;
using System.Text;

namespace DayTemplate
{
    public class Program
    {
        static void Main(string[] args)
        {
            string actualOutput = ProcessInput("input.txt", "DayTemplate");
            Console.WriteLine(AppContext.BaseDirectory);
            Console.WriteLine(actualOutput);
        }
        
        public static string ProcessInput(string inputFile, string day)
        {
            string baseDirectory = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
            string fullFilePath = baseDirectory + "/" + day + "/Inputs/" + inputFile;
            StringBuilder output = new StringBuilder();
            const Int32 BufferSize = 128;
            
            using (var fileStream = File.OpenRead(fullFilePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Process each line and append to output
                    output.AppendLine(line);
                }
            }
            return output.ToString().Trim();            
        }
    }
}