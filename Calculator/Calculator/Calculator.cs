using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        private enum State
        {
            Operand1,
            Operator,
            Operand2,
            Result
        }

        private float operand1 = 0;
        private float operand2 = 0;
        private char currentOperator = '\0';
        private string currentExpression = String.Empty;
        private State state = State.Operand1;

        public void ProcessInput(char input)
        {
            switch (state)
            {
                case State.Operand1:
                    {
                        currentExpression += input;
                        if (char.IsDigit(input))
                        {
                            operand1 = operand1 * 10 + float.Parse(input.ToString());
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            state = State.Operator;
                            currentOperator = input;
                        }
                        break;
                    }
                case State.Operator:
                    {
                        if (char.IsDigit(input))
                        {
                            currentExpression += input;
                            state = State.Operand2;
                            operand2 = operand2 * 10 + float.Parse(input.ToString()); ;
                        }
                    }
                    break;
                case State.Operand2:
                    {
                        if (char.IsDigit(input))
                        {
                            operand2 = operand2 * 10 + float.Parse(input.ToString()); ;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            state = State.Operator;
                            if (currentOperator == '+')
                            {
                                operand1 += operand2;
                            }
                            else if (currentOperator == '-')
                            {
                                operand1 -= operand2;
                            }
                            else if (currentOperator == '*')
                            {
                                operand1 *= operand2;
                            }
                            else if (currentOperator == '/')
                            {
                                if (Math.Abs(operand2) < 0.00000000001)
                                {
                                    throw new DivideByZeroException("Division by zero.");
                                }

                                operand1 /= operand2;
                            }
                            currentExpression = operand1.ToString() + input;
                            operand2 = 0;
                            currentOperator = input;
                        }
                        else if (input == '=')
                        {
                            state = State.Operand1;
                            if (currentOperator == '+')
                            {
                                operand1 += operand2;
                            }
                            else if (currentOperator == '-')
                            {
                                operand1 -= operand2;
                            }
                            else if (currentOperator == '*')
                            {
                                operand1 *= operand2;
                            }
                            else if (currentOperator == '/')
                            {
                                if (Math.Abs(operand2) < 0.00000000001)
                                {
                                    throw new DivideByZeroException("Division by zero.");
                                }

                                operand1 /= operand2;
                            }
                            currentExpression = operand1.ToString();
                            operand2 = 0;
                            currentOperator = '\0';
                        }
                        break;
                    }
                case State.Result:
                    {
                        break;
                    }
            }
        }

        public string GetValue()
        {
            return currentExpression;
        }
    }
}
