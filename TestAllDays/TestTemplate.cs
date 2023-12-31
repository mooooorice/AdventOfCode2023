namespace TestTemplate;

using Day10ToEnd;

public class TestDay10
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTemplateWithTestinput()
    {
        int expectedOutput = 1;
        var run = new Day10();
        int testOutput = run.ProcessInput("testinput.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void TestTemplateWithFinalInput()
    {
        int expectedOutput = 0;
        var run = new Day10();
        int testOutput = run.ProcessInput("input.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
}