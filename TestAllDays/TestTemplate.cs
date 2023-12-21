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
        string expectedOutput = "TESTINPUT"; // Replace with actual expected output
        string testOutput = Program.ProcessInput("testinput.txt");
        StringAssert.AreEqualIgnoringCase(expectedOutput, testOutput);
    }
    
    [Test]
    public void TestTemplateWithFinalInput()
    {
        string expectedOutput = "FINALINPUT"; // Replace with actual expected output
        string testOutput = Program.ProcessInput("input.txt");
        StringAssert.AreEqualIgnoringCase(expectedOutput, testOutput);
    }
}