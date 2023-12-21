namespace TestTemplate;
using Day06;

public class TestDay06
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestDay06TestInput()
    {
        int expectedOutput = 288; 
        int testOutput = Program.ProcessInput("testinput.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
    
    [Test]
    public void TestDa06ActualInput()
    {
        int expectedOutput = 227850; 
        int testOutput = Program.ProcessInput("input.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
}