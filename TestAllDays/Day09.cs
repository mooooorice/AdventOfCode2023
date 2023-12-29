namespace TestTemplate;

using Day09;

public class TestDay09
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestEndSumWithTestinput()
    {
        int expectedOutput = 114;
        var run = new Part1And2("testinput.txt");
        int testOutput = run.SumEnd();
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
    [Test]
    public void TestBeginningSumWithTestInput()
    {
        int expectedOutput = 2;
        var run = new Part1And2("testinput.txt");
        int testOutput = run.SumBeginning();
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
    [Test]
    public void TestEndSumWithFinalInput()
    {
        int expectedOutput = 1584748274;
        var run = new Part1And2("input.txt");
        int testOutput = run.SumEnd();
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
    
    [Test]
    public void TestBeginningSumWithFinalInput()
    {
        int expectedOutput = 1026;
        var run = new Part1And2("input.txt");
        int testOutput = run.SumBeginning();
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
}