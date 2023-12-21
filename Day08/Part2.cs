using System.Reflection;
using System.Text;

namespace Day08
{
    public class Part2
    {
        static string day = "Day08";
        public IDictionary<string, Element> network = new Dictionary<string, Element>();
        public List<string> startNames = new List<string>();

        public class Element
        {
            public string? Name { get; set; }
            public string? Left { get; set; }
            public string? Right { get; set; }
        }

        void processLine(string line)
        {
            Element node = new Element
            {
                Name = line.Substring(0, 3),
                Left = line.Substring(7, 3),
                Right = line.Substring(12, 3)
            };
            network.Add(node.Name, node);
            if (node.Name.EndsWith('A'))
            {
                startNames.Add(node.Name);
            }
        }

        public int ProcessInput(string inputFile)
        {
            string baseDirectory =
                Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
            string fullFilePath = baseDirectory + "/" + day + "/Inputs/" + inputFile;
            StringBuilder output = new StringBuilder();
            const Int32 BufferSize = 128;

            using (var fileStream = File.OpenRead(fullFilePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                string directions = streamReader.ReadLine() ?? throw new InvalidOperationException();
                streamReader.ReadLine();

                while ((line = streamReader.ReadLine()!) != null)
                {
                    processLine(line);
                }

                int steps = 0;
                int nNames = startNames.Count;
                Element[] currentNodes = new Element[nNames];
                for (int i = 0; i < nNames; i++)
                {
                    network.TryGetValue(startNames[i], out currentNodes[i]);
                }

                for (int j = 0; j < 10e42; j++)
                {
                    foreach (char c in directions)
                    {
                        if (c == 'L')
                        {
                            for (int i = 0; i < nNames; i++)
                            {
                                network.TryGetValue(currentNodes[i].Left, out currentNodes[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < nNames; i++)
                            {
                                network.TryGetValue(currentNodes[i].Right, out currentNodes[i]);
                            }
                        }

                        steps++;

                        bool success = true;
                        for (int i = 0; i < nNames; i++)
                        {
                            if (!currentNodes[i].Name.EndsWith('Z'))
                            {
                                success = false;
                            }
                        }
                        if (success)
                        {
                            return steps;
                        }
                    }
                }

                return -1;
            }
        }
    }
}