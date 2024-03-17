using System.Reflection.Emit;
interface IOperator
{
    public Operand Calculate(Operand operand1, Operand operand2); 
}
