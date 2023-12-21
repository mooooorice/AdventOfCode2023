namespace TestTemplate;
using Day08;

public class Tests08
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTemplateWithTestinput()
    {
        int expectedOutput = 2; 
        var test = new NonStatic();
        int testOutput = test.ProcessInput("testinput.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
    
    [Test]
    public void TestTemplateWithTestinput2()
    {
        int expectedOutput = 6; 
        var test = new NonStatic();
        int testOutput = test.ProcessInput("testinput2.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
        [Test]
        public void TestPart2()
        {
            int expectedOutput = 6; 
            var test = new Part2();
            int testOutput = test.ProcessInput("input3.txt");
            Assert.That(testOutput, Is.EqualTo(expectedOutput));
        }
}