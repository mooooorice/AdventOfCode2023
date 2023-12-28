using System.Reflection;
using System.Text;

namespace Day09
{
    public class Part1And2
    {
        string day = "Day09";
        List<List<int[]>> preprocessed = new List<List<int[]>>();
        private int? endSum;
        private int? beginningSum;

        // This just calls ProcessLine() function for each input line
        public Part1And2(string inputFile)
        {
            string baseDirectory =
                Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
            string fullFilePath = baseDirectory + "/" + day + "/Inputs/" + inputFile;
            const Int32 BufferSize = 128;

            using (var fileStream = File.OpenRead(fullFilePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()!) != null)
                {
                    ProcessLine(line);
                }
            }
        }

        private void ProcessLine(string line)
        {
            List<int[]> preprocessedLine = new List<int[]>();
            preprocessedLine.Add(line.Split(' ').Select(x => int.Parse(x)).ToArray());

            int previousImaginaryLine = 0;
            int nextImaginaryLineLength = preprocessedLine[previousImaginaryLine].Length - 1;
            while (preprocessedLine[previousImaginaryLine][nextImaginaryLineLength] != 0 || preprocessedLine[previousImaginaryLine][0] != 0)
            {
                int[] imagianrySeries = new int[nextImaginaryLineLength];
                for (int i = 0; i < nextImaginaryLineLength; i++)
                {
                    imagianrySeries[i] = preprocessedLine[previousImaginaryLine][i + 1] - preprocessedLine[previousImaginaryLine][i];
                }

                preprocessedLine.Add(imagianrySeries);
                previousImaginaryLine++;
                nextImaginaryLineLength--;
            }

            preprocessed.Add(preprocessedLine);
        }

        public int SumEnd()
        {
            if (endSum is null)
            {
                return SumUp(SumFunctionEnd);
            }

            return (int)endSum;
        }

        public int SumBeginning()
        {
            if (beginningSum is null)
            {
                return SumUp(SumFunctionBeginning);
            }

            return (int)beginningSum;
        }

        private int SumUp(Func<List<int[]>, int, int, int, int> sumFunction)
        {
            int totalSum = 0;
            foreach (List<int[]> preprocessedLine in preprocessed){
                int numberOfImaginaryLines = preprocessedLine.Count - 1;
                int imaginaryLineLength = preprocessedLine[numberOfImaginaryLines].Length;
                int lineSum = 0;
                for (int imaginaryLine = numberOfImaginaryLines; imaginaryLine >= 0; imaginaryLine--)
                {
                    lineSum = sumFunction(preprocessedLine, lineSum, imaginaryLine, imaginaryLineLength);
                    imaginaryLineLength++;
                }
                totalSum += lineSum;
            }
            return totalSum;
        }

        private int SumFunctionEnd(List<int[]> preprocessedLine, int toAdd, int row, int lineLength)
        {
            toAdd = preprocessedLine[row][lineLength-1] + toAdd;
            return toAdd;
        }

        private int SumFunctionBeginning(List<int[]> preprocessedLine, int toAdd, int row, int lineLength)
        {
            toAdd = preprocessedLine[row][0] - toAdd;
            return toAdd;
        }
    }
}