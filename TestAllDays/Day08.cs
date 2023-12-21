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
        int testOutput = Program.ProcessInput("testinput.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
    
    [Test]
    public void TestTemplateWithTestinput2()
    {
        int expectedOutput = 6; 
        int testOutput = Program.ProcessInput("testinput2.txt");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
    }
    
    [Test]
    public void TestTemplateWithFinalInput()
    {
        Program.Element networkElement;
        Program.network.TryGetValue("AAA", out networkElement);
        Assert.That(networkElement.Left, Is.EqualTo("CCC"));
        Assert.That(networkElement.Right, Is.EqualTo("BBB"));
    }
}