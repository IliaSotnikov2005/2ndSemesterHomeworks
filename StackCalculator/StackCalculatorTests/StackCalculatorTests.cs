[TestFixture]
public class StackCalculatorTests
{
    [TestCaseSource(nameof(StackCalculatorTestData))]
    public void Calculate_ValidExpressions_ReturnsCorrectResult(IStack<float> stack)
    {
        string[] inputs =
        [
        "3 4 +",
        "5 2 -",
        "-4 6 *",
        "10 2 /",
        "8 84 21 8 1 1 2 3 * - + + * / -",
        ];
        int[] expected = [7, 3, -24, 5];

        for (int i = 0; i < expected.Length; ++i)
        {
            float actual = StackCalculator.Calculate(inputs[i], stack);

            Assert.That(actual, Is.EqualTo(expected[i]));
        }
    }

    [TestCaseSource(nameof(StackCalculatorTestData))]
    public void Calculate_DivisionByZero_ThrowsException(IStack<float> stack)
    {
        string input = "5 0 /";

        Assert.Throws<DivideByZeroException>(() => StackCalculator.Calculate(input, stack));
    }

    [TestCaseSource(nameof(StackCalculatorTestData))]
    public void Calculate_InvalidExpressions_ThrowsException(IStack<float> stack)
    {
        string[] inputs =
        [
        "5 2 #",
        "3 2 t 3 + + +",
        "3 3 3 -",
        "",
        ];
        for (int i = 0; i < inputs.Length; ++i)
        {
            Assert.Throws<ArgumentException>(() => StackCalculator.Calculate(inputs[i], stack));
        }
    }

    private static IEnumerable<TestCaseData> StackCalculatorTestData()
    {
        yield return new TestCaseData(new StackOnList<float>());
        yield return new TestCaseData(new StackOnArray<float>());
    }
}
