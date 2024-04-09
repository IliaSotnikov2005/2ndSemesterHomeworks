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
            Operand1FractionalPart,
            Operand2FractionalPart
        }

        private float operand1 = 0;
        private float operand2 = 0;
        private int operand1FractionalPartDigitCount = 0;
        private int operand2FractionalPartDigitCount = 0;
        private char currentOperator = '\0';
        private string currentExpression = String.Empty;
        private State state = State.Operand1;

        public void ProcessInput(char input)
        {
            switch (state)
            {
                case State.Operand1:
                    {
                        if (!float.TryParse(currentExpression, out float result))
                        {
                            currentExpression = string.Empty;
                        }

                        if (char.IsDigit(input))
                        {
                            operand1 = operand1 * 10 + float.Parse(input.ToString());
                            currentExpression += input;
                        }
                        else if (input == '.')
                        {
                            state = State.Operand1FractionalPart;
                            currentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            state = State.Operator;
                            currentOperator = input;
                            currentExpression += input;
                        }
                        else if (input == 'C')
                        {
                            SetDefaults();
                        }

                        break;
                    }
                case State.Operator:
                    {
                        if (char.IsDigit(input))
                        {
                            state = State.Operand2;
                            operand2 = operand2 * 10 + float.Parse(input.ToString());
                            currentExpression += input;
                        }
                        else if (input == 'C')
                        {
                            SetDefaults();
                        }

                        break;
                    }
                case State.Operand2:
                    {
                        if (char.IsDigit(input))
                        {
                            operand2 = operand2 * 10 + float.Parse(input.ToString());
                            currentExpression += input;
                        }
                        else if (input == '.')
                        {
                            state = State.Operand2FractionalPart;
                            currentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            state = State.Operator;
                            try
                            {
                                Calculate();
                                currentExpression += input;
                            }
                            catch (DivideByZeroException)
                            {
                                state = State.Operand1;
                                SetDefaults();
                                currentExpression = "ERROR";
                            }

                            currentOperator = input;
                        }
                        else if (input == '=')
                        {
                            state = State.Operand1;
                            try
                            {
                                Calculate();
                            }
                            catch (DivideByZeroException)
                            {
                                state = State.Operand1;
                                SetDefaults();
                                currentExpression = "ERROR";
                            }
                        }
                        else if (input == 'C')
                        {
                            SetDefaults();
                        }

                        break;
                    }
                case State.Operand1FractionalPart:
                    {
                        if (char.IsDigit(input))
                        {
                            operand1FractionalPartDigitCount++;
                            operand1 += (float)Math.Pow(0.1, operand1FractionalPartDigitCount) * float.Parse(input.ToString());
                            currentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            state = State.Operator;
                            currentOperator = input;
                            currentExpression += input;
                        }
                        else if (input == '=')
                        {
                            state = State.Operand1;
                            try
                            {
                                Calculate();
                            }
                            catch (DivideByZeroException)
                            {
                                state = State.Operand1;
                                SetDefaults();
                                currentExpression = "ERROR";
                            }
                        }
                        else if (input == 'C')
                        {
                            SetDefaults();
                        }

                        break;
                    }
                case State.Operand2FractionalPart:
                    {
                        if (char.IsDigit(input))
                        {
                            operand2FractionalPartDigitCount++;
                            operand2 += (float)Math.Pow(0.1, operand2FractionalPartDigitCount) * float.Parse(input.ToString());
                            currentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            state = State.Operator;
                            try
                            {
                                Calculate();
                            }
                            catch (DivideByZeroException)
                            {
                                state = State.Operand1;
                                SetDefaults();
                                currentExpression = "ERROR";
                            }

                            currentExpression += input;
                        }
                        else if (input == '=')
                        {
                            state = State.Operand1;
                            try
                            {
                                Calculate();
                            }
                            catch (DivideByZeroException)
                            {
                                state = State.Operand1;
                                SetDefaults();
                                currentExpression = "ERROR";
                            }
                        }
                        else if (input == 'C')
                        {
                            SetDefaults();
                        }

                        break;
                    }
            }
        }

        private void Calculate()
        {
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

            operand2 = 0;
            operand1FractionalPartDigitCount = 0;
            operand2FractionalPartDigitCount = 0;
            currentExpression = operand1.ToString();
            currentOperator = '\0';
        }

        private void SetDefaults()
        {
            operand1 = 0;
            operand2 = 0;
            currentExpression = String.Empty;
            currentOperator = '\0';
            operand1FractionalPartDigitCount = 0;
            operand2FractionalPartDigitCount = 0;
        }
        public string GetExpresiion()
        {
            return currentExpression;
        }
    }
}
