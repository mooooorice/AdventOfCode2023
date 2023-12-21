namespace TestTemplate;
using Day06;

public class TestDay06
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTemplateWithTestinput()
    {
        int expectedOutput = 288; 
        int testOutput = Program.ProcessInput("testinput.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
    
    [Test]
    public void TestTemplateWithFinalInput()
    {
        int expectedOutput = 227850; 
        int testOutput = Program.ProcessInput("input.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
}