// <copyright file="Calculator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calculator
{
    using System;

    /// <summary>
    /// Calculator class.
    /// </summary>
    public class Calculator
    {
        private float operand1 = 0;
        private float operand2 = 0;
        private int operand1FractionalPartDigitCount = 0;
        private int operand2FractionalPartDigitCount = 0;
        private char currentOperator = '\0';
        private string currentExpression = string.Empty;
        private State state = State.Start;

        private enum State
        {
            Start,
            Operand1,
            Operator,
            Operand2,
            Operand1FractionalPart,
            Operand2FractionalPart,
        }

        /// <summary>
        /// Process the input.
        /// </summary>
        /// <param name="input">Input for calculator.</param>
        public void ProcessInput(char input)
        {
            switch (this.state)
            {
                case State.Start:
                    {
                        if (!float.TryParse(this.currentExpression, out float result))
                        {
                            this.currentExpression = string.Empty;
                        }

                        if (char.IsDigit(input))
                        {
                            this.operand1 = (this.operand1 * 10) + float.Parse(input.ToString());
                            this.currentExpression += input;
                            this.state = State.Operand1;
                        }

                        break;
                    }

                case State.Operand1:
                    {
                        if (char.IsDigit(input))
                        {
                            this.operand1 = (this.operand1 * 10) + float.Parse(input.ToString());
                            this.currentExpression += input;
                        }
                        else if (input == '.')
                        {
                            this.state = State.Operand1FractionalPart;
                            this.currentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            this.state = State.Operator;
                            this.currentOperator = input;
                            this.currentExpression += input;
                        }
                        else if (input == 'C')
                        {
                            this.SetDefaults();
                        }

                        break;
                    }

                case State.Operator:
                    {
                        if (char.IsDigit(input))
                        {
                            this.state = State.Operand2;
                            this.operand2 = (this.operand2 * 10) + float.Parse(input.ToString());
                            this.currentExpression += input;
                        }
                        else if (input == 'C')
                        {
                            this.SetDefaults();
                        }

                        break;
                    }

                case State.Operand2:
                    {
                        if (char.IsDigit(input))
                        {
                            this.operand2 = (this.operand2 * 10) + float.Parse(input.ToString());
                            this.currentExpression += input;
                        }
                        else if (input == '.')
                        {
                            this.state = State.Operand2FractionalPart;
                            this.currentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            this.state = State.Operator;
                            try
                            {
                                this.Calculate();
                                this.currentExpression += input;
                            }
                            catch (DivideByZeroException)
                            {
                                this.state = State.Operand1;
                                this.SetDefaults();
                                this.currentExpression = "ERROR";
                            }

                            this.currentOperator = input;
                        }
                        else if (input == '=')
                        {
                            this.state = State.Operand1;
                            try
                            {
                                this.Calculate();
                            }
                            catch (DivideByZeroException)
                            {
                                this.state = State.Operand1;
                                this.SetDefaults();
                                this.currentExpression = "ERROR";
                            }
                        }
                        else if (input == 'C')
                        {
                            this.SetDefaults();
                        }

                        break;
                    }

                case State.Operand1FractionalPart:
                    {
                        if (char.IsDigit(input))
                        {
                            this.operand1FractionalPartDigitCount++;
                            this.operand1 += (float)Math.Pow(0.1, this.operand1FractionalPartDigitCount) * float.Parse(input.ToString());
                            this.currentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            this.state = State.Operator;
                            this.currentOperator = input;
                            this.currentExpression += input;
                        }
                        else if (input == '=')
                        {
                            this.state = State.Operand1;
                            try
                            {
                                this.Calculate();
                            }
                            catch (DivideByZeroException)
                            {
                                this.state = State.Operand1;
                                this.SetDefaults();
                                this.currentExpression = "ERROR";
                            }
                        }
                        else if (input == 'C')
                        {
                            this.SetDefaults();
                        }

                        break;
                    }

                case State.Operand2FractionalPart:
                    {
                        if (char.IsDigit(input))
                        {
                            this.operand2FractionalPartDigitCount++;
                            this.operand2 += (float)Math.Pow(0.1, this.operand2FractionalPartDigitCount) * float.Parse(input.ToString());
                            this.currentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            this.state = State.Operator;
                            try
                            {
                                this.Calculate();
                            }
                            catch (DivideByZeroException)
                            {
                                this.state = State.Operand1;
                                this.SetDefaults();
                                this.currentExpression = "ERROR";
                            }

                            this.currentExpression += input;
                        }
                        else if (input == '=')
                        {
                            this.state = State.Operand1;
                            try
                            {
                                this.Calculate();
                            }
                            catch (DivideByZeroException)
                            {
                                this.state = State.Operand1;
                                this.SetDefaults();
                                this.currentExpression = "ERROR";
                            }
                        }
                        else if (input == 'C')
                        {
                            this.SetDefaults();
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Get current expression.
        /// </summary>
        /// <returns>Current expression.</returns>
        public string GetExpresiion()
        {
            return this.currentExpression;
        }

        private void Calculate()
        {
            if (this.currentOperator == '+')
            {
                this.operand1 += this.operand2;
            }
            else if (this.currentOperator == '-')
            {
                this.operand1 -= this.operand2;
            }
            else if (this.currentOperator == '*')
            {
                this.operand1 *= this.operand2;
            }
            else if (this.currentOperator == '/')
            {
                if (Math.Abs(this.operand2) < 0.00000000001)
                {
                    throw new DivideByZeroException("Division by zero.");
                }

                this.operand1 /= this.operand2;
            }

            this.operand2 = 0;
            this.operand1FractionalPartDigitCount = 0;
            this.operand2FractionalPartDigitCount = 0;
            this.currentExpression = this.operand1.ToString();
            this.currentOperator = '\0';
        }

        private void SetDefaults()
        {
            this.operand1 = 0;
            this.operand2 = 0;
            this.currentExpression = string.Empty;
            this.currentOperator = '\0';
            this.operand1FractionalPartDigitCount = 0;
            this.operand2FractionalPartDigitCount = 0;
            this.state = State.Start;
        }
    }
}
