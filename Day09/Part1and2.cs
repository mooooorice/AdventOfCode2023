using System.Collections.Immutable;
using System.Reflection;
using System.Text;

namespace Day09
{
    public class Part1And2
    {
        string day = "Day09";
        private ImmutableArray<ImmutableArray<int[]>> preprocessed;
        private int? endSum;
        private int? beginningSum;

        // This just calls ProcessLine() function for each input line and writes to preprocesseed
        public Part1And2(string inputFile)
        {
            string baseDirectory =
                Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
            string fullFilePath = Path.Combine(baseDirectory, day, "Inputs", inputFile);
            const Int32 BufferSize = 128;

            using (var fileStream = File.OpenRead(fullFilePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                List<ImmutableArray<int[]>> preprocessedList = new List<ImmutableArray<int[]>>();
                string? line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    preprocessedList.Add(ProcessLine(line));
                }

                preprocessed = preprocessedList.ToImmutableArray();
            }
        }

        private ImmutableArray<int[]> ProcessLine(string? line)
        {
            List<int[]> preprocessedLine = new List<int[]>();
            preprocessedLine.Add(line.Split(' ').Select(x => int.Parse(x)).ToArray());

            int previousImaginaryLine = 0;
            int nextImaginaryLineLength = preprocessedLine[previousImaginaryLine].Length - 1;
            while (preprocessedLine[previousImaginaryLine][nextImaginaryLineLength] != 0 || preprocessedLine[previousImaginaryLine][0] != 0)
            {
                var imagianrySeries = GenerateImaginarySeries(nextImaginaryLineLength, preprocessedLine, previousImaginaryLine);
                preprocessedLine.Add(imagianrySeries);
                previousImaginaryLine++;
                nextImaginaryLineLength--;
            }
            return preprocessedLine.ToImmutableArray();
        }

        private static int[] GenerateImaginarySeries(int nextImaginaryLineLength, IReadOnlyList<int[]> preprocessedLine,
            int previousImaginaryLine)
        {
            int[] imaginarySeries = new int[nextImaginaryLineLength];
            for (int i = 0; i < nextImaginaryLineLength; i++)
            {
                imaginarySeries[i] =
                    preprocessedLine[previousImaginaryLine][i + 1] - preprocessedLine[previousImaginaryLine][i];
            }

            return imaginarySeries;
        }

        // public int SumBeginning() => beginningSum ??= SumUp(SumFunctionEnd);
        public int SumEnd() => endSum ??= SumUpAggregateEnd();

        // public int SumBeginning() => beginningSum ??= SumUp(SumFunctionBeginning);
        public int SumBeginning() => beginningSum ??= SumUpAggregateBeginning();

        private int SumUpAggregateEnd()
        {
            return preprocessed.Sum(preprocessedLine => preprocessedLine.Sum(preprocessedSubLine => preprocessedSubLine.Last()));
        }
        private int SumUpAggregateBeginning()
        {
            return preprocessed.Sum(preprocessedLine => preprocessedLine.Reverse().Aggregate(0,
                (currentSubstractor, preprocessedLine) => preprocessedLine.First() - currentSubstractor));
        }

        private int SumUp(Func<ImmutableArray<int[]>, int, int, int, int> sumFunction)
        {
            int totalSum = 0;
            foreach (ImmutableArray<int[]> preprocessedLine in preprocessed){
                int numberOfImaginaryLines = preprocessedLine.Length - 1;
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

        private int SumFunctionEnd(ImmutableArray<int[]> preprocessedLine, int toAdd, int row, int lineLength)
        {
            toAdd = preprocessedLine[row][lineLength-1] + toAdd;
            return toAdd;
        }

        private int SumFunctionBeginning(ImmutableArray<int[]> preprocessedLine, int toAdd, int row, int lineLength)
        {
            toAdd = preprocessedLine[row][0] - toAdd;
            return toAdd;
        }
    }
}