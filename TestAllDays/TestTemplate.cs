namespace TestTemplate;
using DayTemplate;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTemplateWithTestinput()
    {
        int expectedOutput = 1; 
        int testOutput = Program.ProcessInput("testinput.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
    
    [Test]
    public void TestTemplateWithFinalInput()
    {
        int expectedOutput = 0; 
        int testOutput = Program.ProcessInput("input.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
}