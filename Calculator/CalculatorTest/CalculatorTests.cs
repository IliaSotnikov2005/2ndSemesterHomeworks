namespace CalculatorTests
{
    using Calculator;
    public class CalculatorTests
    {
        [Test]
        public void TestProcessInput_Addition()
        {
            Calculator calc = new Calculator();
            calc.ProcessInput('2');
            calc.ProcessInput('+');
            calc.ProcessInput('3');
            calc.ProcessInput('=');
            Assert.That(calc.CurrentExpression, Is.EqualTo("5"));
        }

        [Test]
        public void TestProcessInput_Subtraction()
        {
            Calculator calc = new Calculator();
            calc.ProcessInput('8');
            calc.ProcessInput('-');
            calc.ProcessInput('3');
            calc.ProcessInput('=');
            Assert.That(calc.CurrentExpression, Is.EqualTo("5"));
        }

        [Test]
        public void TestProcessInput_Multiplication()
        {
            Calculator calc = new Calculator();
            calc.ProcessInput('4');
            calc.ProcessInput('*');
            calc.ProcessInput('5');
            calc.ProcessInput('=');
            Assert.That(calc.CurrentExpression, Is.EqualTo("20"));
        }

        [Test]
        public void TestProcessInput_Division()
        {
            Calculator calc = new Calculator();
            calc.ProcessInput('9');
            calc.ProcessInput('/');
            calc.ProcessInput('3');
            calc.ProcessInput('=');
            Assert.That(calc.CurrentExpression, Is.EqualTo("3"));
        }

        [Test]
        public void TestProcessInput_DivisionByZero()
        {
            Calculator calc = new Calculator();
            calc.ProcessInput('5');
            calc.ProcessInput('/');
            calc.ProcessInput('0');
            calc.ProcessInput('=');
            Assert.That(calc.CurrentExpression, Is.EqualTo("ERROR"));
        }

        [Test]
        public void TestProcessInput_MultipleOperations()
        {
            Calculator calc = new Calculator();
            calc.ProcessInput('5');
            calc.ProcessInput('+');
            calc.ProcessInput('3');
            calc.ProcessInput('*');
            calc.ProcessInput('2');
            calc.ProcessInput('/');
            calc.ProcessInput('4');
            calc.ProcessInput('=');
            Assert.That(calc.CurrentExpression, Is.EqualTo("4"));
        }
    }
}