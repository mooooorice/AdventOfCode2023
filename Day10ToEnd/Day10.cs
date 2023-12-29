using System.Reflection;
using System.Text;

namespace Day10ToEnd
{
    public class Day10
    {
        string day = "Day10";
        public int ProcessInput(string inputFile)
        {
            string baseDirectory = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
            string fullFilePath = Path.Combine(baseDirectory, "Day10ToEnd", "Inputs", day, inputFile);
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

            if (inputFile.Equals("input.txt"))
            {
                return 0;
            }

            return 1;
        }
    }
}