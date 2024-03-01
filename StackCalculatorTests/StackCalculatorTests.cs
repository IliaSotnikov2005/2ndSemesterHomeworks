using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class StackCalculatorTests
{
    [TestCase("3 4 +", 7)]
    [TestCase("5 2 -", 3)]
    [TestCase("-4 6 *", -24)]
    [TestCase("10 2 /", 5)]
    public void Calculate_ValidExpressions_ReturnsCorrectResult(string expression, float expected)
    {
        float actual = StackCalculator.Calculate(expression);
        float actual2 = StackCalculator.Calculate(expression, "array");

        Assert.That(actual, Is.EqualTo(expected));
        Assert.That(actual2, Is.EqualTo(expected));
    }

    [TestCase("5 0 /")]
    public void Calculate_DivisionByZero_ThrowsException(string expression)
    {
        Assert.Throws<DivideByZeroException>(() => StackCalculator.Calculate(expression));
        Assert.Throws<DivideByZeroException>(() => StackCalculator.Calculate(expression, "array"));
    }

    [TestCase("5 2 #")]
    [TestCase("3 2 t 3 + + +")]
    [TestCase("3 3 3 -")]
    [TestCase("")]
    public void Calculate_InvalidExpressions_ThrowsException(string expression)
    {
        Assert.Throws<ArgumentException>(() => StackCalculator.Calculate(expression));
        Assert.Throws<ArgumentException>(() => StackCalculator.Calculate(expression, "array"));
    }


}
