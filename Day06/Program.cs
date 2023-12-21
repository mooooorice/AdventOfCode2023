using System.Reflection;
using System.Text;

namespace Day06
{
    public class Program
    {
        static string day = "Day06";
        static void Main(string[] args)
        {
            int actualOutput = ProcessInput("input.txt");
            Console.WriteLine(AppContext.BaseDirectory);
            Console.WriteLine(actualOutput);
        }
        
        public static int ProcessInput(string inputFile)
        {
            int[] inputTimeTest = {7, 15, 30};
            int[] inputDistanceTest = { 9, 40, 200 };
            int[] inputTimeFinal = {59, 70, 78, 78};
            int[] inputDistanceFinal = {430, 1218, 1213, 1276};
            if (inputFile.Equals("testinput.txt"))
            {
                return getWins(inputTimeTest, inputDistanceTest);
            }

            return getWins(inputTimeFinal, inputDistanceFinal);
        }

        private static int getWins(int[] inputTime, int[] inputDistance)
        {
            int sum = 1;
            for(int i = 0; i < inputDistance.Length; i++)
            {
                sum *= getWin(inputTime[i], inputDistance[i]);
            }

            return sum;
        }

        private static int getWin(int t, int d)
        {
            int sum = 0;
            for (int i = 1; i <= t; i++)
            {
                if((i * (t - i)) > d)
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}