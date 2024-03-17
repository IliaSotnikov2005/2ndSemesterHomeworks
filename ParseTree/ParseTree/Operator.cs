public class Plus : IOperator
{
    public Operand Calculate(Operand operand1, Operand operand2)
    {
        return operand1 + operand2;
    }

    public override string ToString()
    {
        return "+";
    }
}

public class Minus : IOperator
{
    public Operand Calculate(Operand operand1, Operand operand2)
    {
        return operand1 - operand2;
    }

    public override string ToString()
    {
        return "-";
    }
}

public class Multiplication : IOperator
{
    public Operand Calculate(Operand operand1, Operand operand2)
    {
        return operand1 * operand2;
    }

    public override string ToString()
    {
        return "*";
    }
}

public class Division : IOperator
{
    public Operand Calculate(Operand operand1, Operand operand2)
    {
        if (operand2.Value == 0)
        {
            throw new DivideByZeroException();
        }

        return operand1 / operand2;   
    }

    public override string ToString()
    {
        return "/";
    }
}