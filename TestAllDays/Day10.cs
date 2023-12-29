namespace TestTemplate;

using DayTemplate;

public class TestTemplate
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTemplateWithTestinput()
    {
        int expectedOutput = 1;
        var run = new Part1();
        int testOutput = run.ProcessInput("testinput.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void TestTemplateWithFinalInput()
    {
        int expectedOutput = 0;
        var run = new Part1();
        int testOutput = run.ProcessInput("input.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
}