namespace CalculatorTest
{
    using Calculator;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestTest()
        {
            Calculator calculator = new Calculator();
            calculator.ProcessInput('1');
            calculator.ProcessInput('+');
            calculator.ProcessInput('2');
            Assert.That(calculator.GetExpresiion(), Is.EqualTo("1+2"));
        }
    }
}
