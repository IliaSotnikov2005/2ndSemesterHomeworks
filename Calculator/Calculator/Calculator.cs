// <copyright file="Calculator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calculator
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    /// <summary>
    /// Calculator class.
    /// </summary>
    public class Calculator : INotifyPropertyChanged
    {
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char currentOperator = '\0';
        private State state = State.Start;
        private string currentExpression;

        /// <summary>
        /// Event handler for expression change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
        /// Gets currentExpression.
        /// </summary>
        public string CurrentExpression
        {
            get => this.currentExpression;

            private set
            {
                this.currentExpression = value;
                this.NotifyPropertyChanged("CurrentExpression");
            }
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
                        if (!float.TryParse(this.CurrentExpression, out float result))
                        {
                            this.CurrentExpression = string.Empty;
                        }

                        if (char.IsDigit(input))
                        {
                            this.operand1 += input.ToString();
                            this.CurrentExpression += input;
                            this.state = State.Operand1;
                        }

                        break;
                    }

                case State.Operand1:
                    {
                        if (char.IsDigit(input))
                        {
                            this.operand1 += input.ToString();
                            this.CurrentExpression += input;
                        }
                        else if (input == '.')
                        {
                            this.state = State.Operand1FractionalPart;
                            this.operand1 += input;
                            this.CurrentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            this.state = State.Operator;
                            this.currentOperator = input;
                            this.CurrentExpression += input;
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
                            this.operand1 += input.ToString();
                            this.CurrentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            this.state = State.Operator;
                            this.currentOperator = input;
                            this.CurrentExpression += input;
                        }
                        else if (input == '=')
                        {
                            this.state = State.Operand1;
                            this.TryCalculate();
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
                            this.operand2 += input.ToString();
                            this.CurrentExpression += input;
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
                            this.operand2 += input.ToString();
                            this.CurrentExpression += input;
                        }
                        else if (input == '.')
                        {
                            this.state = State.Operand2FractionalPart;
                            this.CurrentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            this.state = State.Operator;
                            this.TryCalculate();

                            this.currentOperator = input;
                            this.CurrentExpression += input;
                        }
                        else if (input == '=')
                        {
                            this.state = State.Operand1;
                            this.TryCalculate();
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
                            this.operand2 += input.ToString();
                            this.CurrentExpression += input;
                        }
                        else if (input == '+' || input == '-' || input == '*' || input == '/')
                        {
                            this.state = State.Operator;
                            this.TryCalculate();

                            this.CurrentExpression += input;
                            this.currentOperator = input;
                        }
                        else if (input == '=')
                        {
                            this.state = State.Operand1;
                            this.TryCalculate();
                        }
                        else if (input == 'C')
                        {
                            this.SetDefaults();
                        }

                        break;
                    }
            }
        }

        private void TryCalculate()
        {
            try
            {
                this.Calculate();
            }
            catch (DivideByZeroException)
            {
                this.state = State.Operand1;
                this.SetDefaults();
                this.CurrentExpression = "ERROR";
            }
        }

        private void Calculate()
        {
            float number1 = float.Parse(this.operand1, CultureInfo.InvariantCulture);
            float number2 = float.Parse(this.operand2, CultureInfo.InvariantCulture);

            if (this.currentOperator == '+')
            {
                number1 += number2;
            }
            else if (this.currentOperator == '-')
            {
                number1 -= number2;
            }
            else if (this.currentOperator == '*')
            {
                number1 *= number2;
            }
            else if (this.currentOperator == '/')
            {
                if (Math.Abs(number2) < 0.00000000001)
                {
                    throw new DivideByZeroException("Division by zero.");
                }

                number1 /= number2;
            }

            this.operand1 = number1.ToString();
            this.operand2 = string.Empty;
            this.CurrentExpression = this.operand1.ToString();
            this.currentOperator = '\0';
        }

        private void SetDefaults()
        {
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;
            this.CurrentExpression = string.Empty;
            this.currentOperator = '\0';
            this.state = State.Start;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
