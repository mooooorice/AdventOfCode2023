using System.Reflection;
using System.Text;

namespace Day08
{
    public class NonStatic
    {
        static string day = "Day08";
        public IDictionary<string, Element> network = new Dictionary<string, Element>();

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
        }

        public int ProcessInput(string inputFile)
        {
            string baseDirectory = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
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
                Element currentNode;
                network.TryGetValue("AAA", out currentNode!);
                for (int i = 0; i < 10e42; i++)
                {
                    foreach (char c in directions)
                    {
                        if (c == 'L')
                        {
                            network.TryGetValue(currentNode.Left!, out currentNode!);
                        }
                        else
                        {
                            network.TryGetValue(currentNode.Right!, out currentNode!);
                        }

                        steps++;

                        if (currentNode!.Name!.Equals("ZZZ"))
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