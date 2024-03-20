public class Operand(int value) : IEdgeContent
{
    public int Value { get; set; } = value;

    public static Operand operator +(Operand operand1, Operand operand2) => new(operand1.Value + operand2.Value);

    public static Operand operator -(Operand operand1, Operand operand2) => new(operand1.Value - operand2.Value);

    public static Operand operator *(Operand operand1, Operand operand2) => new(operand1.Value * operand2.Value);

    public static Operand operator /(Operand operand1, Operand operand2)
    {
        if (operand2.Value == 0)
        {
            throw new DivideByZeroException();
        }

        return new(operand1.Value / operand2.Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}