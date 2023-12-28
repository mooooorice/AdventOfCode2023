namespace TestTemplate;

using Day09;

public class TestDay09
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTemplateWithTestinput()
    {
        int expectedOutput = 114;
        var run = new Part1And2("testinput.txt");
        // int testOutput = run.ProcessInput("testinput.txt");
        // Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void TestTemplateWithFinalInput()
    {
        int expectedOutput = 0;
        var run = new Part1And2();
        // int testOutput = run.ProcessInput("input.txt");
        // Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
}