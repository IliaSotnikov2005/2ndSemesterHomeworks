public class Operand(int value)
{
    public int Value { get; set; } = value;

    public static Operand operator +(Operand operand1, Operand operand2) => new Operand(operand1.Value + operand2.Value);

    public static Operand operator -(Operand operand1, Operand operand2) => new Operand(operand1.Value - operand2.Value);

    public static Operand operator *(Operand operand1, Operand operand2) => new Operand(operand1.Value * operand2.Value);

    public static Operand operator /(Operand operand1, Operand operand2)
    {
        if (operand2.Value == 0)
        {
            throw new DivideByZeroException();
        }

        return new Operand(operand1.Value / operand2.Value);
    }

}