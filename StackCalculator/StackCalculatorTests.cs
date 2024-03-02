/// <summary>
/// Stack calculator tests class.
/// </summary>
public static class StackCalculatorTests
{
    /// <summary>
    /// Stack calculator test.
    /// </summary>
    /// <returns>True is all tests passed, else false.</returns>
    public static bool Test()
    {
        string[] inputs = { "1 2 3 4 + + -", "6 216 3 8 4 + * / -", "1 0 /" };
        float[] expected = { -8, 0, 0 };
        bool[] results = new bool[inputs.Length];
        for (int i = 0; i < inputs.Length; ++i)
        {
            try
            {
                float result = StackCalculator.Calculate(inputs[i], new StackOnList<float>());

                results[i] = Math.Abs(result - expected[i]) <= Math.Abs(result * 0.000001f);
            }
            catch (DivideByZeroException)
            {
                results[i] = i == 2;
            }
        }

        return results.All(x => x);
    }
}
