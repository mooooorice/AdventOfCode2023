using System.Reflection;
using System.Text;

namespace Day09
{
    public class Part1And2
    {
        string day = "Day09";

        public int ProcessInput(Func<int, List<int[]>, int, int, int> sumFunction, string inputFile)
        {
            string baseDirectory = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
            string fullFilePath = baseDirectory + "/" + day + "/Inputs/" + inputFile;
            StringBuilder output = new StringBuilder();
            const Int32 BufferSize = 128;
            
            int sum = 0;
            using (var fileStream = File.OpenRead(fullFilePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()!) != null)
                {
                    // Process each line and append to output
                    sum += ProcessLine(sumFunction, line);
                }
            }
            return sum;
        }

        private int ProcessLine(Func<int, List<int[]>, int, int, int> sumFunction, string line)
        {
            List<int[]> all = new List<int[]>();
            int[] series = line.Split(' ').Select(x => int.Parse(x)).ToArray();
            all.Add(series);
            int currentLine = 0;
            int lineLength = all[currentLine].Length;
            while (all[currentLine][lineLength-1] != 0 || all[currentLine][0] != 0)
            {
                int[] imagianrySeries = new int[lineLength-1];
                lineLength--;
                for (int i = 0; i < lineLength; i++)
                {
                    imagianrySeries[i] = all[currentLine][i + 1] - all[currentLine][i];
                }
                currentLine++;
                all.Add(imagianrySeries);
            }
            int toAdd = 0;
            for (int i = currentLine-1; i >= 0; i--)
            {
                toAdd = sumFunction(toAdd, all, i, lineLength);
                lineLength++;
            }

            return toAdd;
        }

        public static int sumFunctionEnd(int toAdd, List<int[]> all, int i, int lineLength)
        {
            toAdd = all[i][lineLength] + toAdd;
            return toAdd;
        }
        public static int sumFunctionBeginning(int toAdd, List<int[]> all, int i, int lineLength)
        {
            toAdd = all[i][0] - toAdd;
            return toAdd;
        }
    }
}