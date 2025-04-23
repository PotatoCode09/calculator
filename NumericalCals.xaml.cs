using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for NumericalCals.xaml
    /// </summary>
    /// 
    
    public partial class NumericalCals : Page
    {
        private const int MaxDigits = 32;
        public static NumericalCals Instance { get; private set; }

        private string _currentExpression = ""; // Tracks the ongoing operation in the TextBlock
        private bool _isNewCalculation = true;  // Tracks if a new calculation should start
        private int _currentBase = 10;

        public NumericalCals()
        {
            InitializeComponent();
            Instance = this;  // Set instance
        }

        public void LoadCalculatorPage(Page calculatorPage)
        {
            SecondaryFrame.Navigate(calculatorPage);
        }


        private void TypeHere_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string input = e.Text;
            string currentText = TypeHere.Text;

            // Allow numbers
            if (char.IsDigit(input, 0))
            {
                e.Handled = false;
                return;
            }

            // Allow letters A–F (case-insensitive) if the current base is hexadecimal
            if (_currentBase == 16 && "ABCDEFabcdef".Contains(input))
            {
                e.Handled = false;
                return;
            }

            // Allow a single decimal point per number
            if (input == "." && !currentText.Contains("."))
            {
                e.Handled = false;
                return;
            }

            // Allow operators only if the last character is a number
            if ((input == "+" || input == "-" || input == "×" || input == "÷") &&
                char.IsDigit(currentText.LastOrDefault()))
            {
                e.Handled = false;
                return;
            }

            // Block all other inputs
            e.Handled = true;
        }

        public void SetBase(int newBase)
        {
            try
            {
                // Convert the current value in TypeHere to the new base
                string input = TypeHere.Text;
                string convertedValue = ConvertBase(input, _currentBase, newBase);

                // Update the TextBox and TextBlock
                TypeHere.Text = convertedValue;
                Expression.Text = $"Base {_currentBase} → Base {newBase}: {input} → {convertedValue}";

                // Update the current base
                _currentBase = newBase;
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
                Expression.Text = "Error converting base.";
            }
        }

        private string ConvertBase(string input, int fromBase, int toBase)
        {
            // Convert the input to decimal (base 10)
            long decimalValue = Convert.ToInt64(input, fromBase);

            // Convert the decimal value to the target base
            return toBase switch
            {
                2 => Convert.ToString(decimalValue, 2),  // Binary
                8 => Convert.ToString(decimalValue, 8),  // Octal
                10 => decimalValue.ToString(),           // Decimal
                16 => decimalValue.ToString("X"),        // Hexadecimal
                _ => throw new InvalidOperationException("Unsupported base")
            };
        }

        private void TypeHere_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Ensure the Programmer page is loaded in the SecondaryFrame
            if (SecondaryFrame != null && SecondaryFrame.Content is Programmer programmerPage )
            {
                programmerPage.UpdateConversions(TypeHere.Text);
            }
        }

        public void AppendToTextBox(string text)
        {
            // If a new calculation is starting, clear the TextBox
            if (_isNewCalculation)
            {
                TypeHere.Text = text;
                _isNewCalculation = false; // Reset the flag
            }
            else
            {
                if (TypeHere.Text.Length >= MaxDigits)
                    return;

                if (TypeHere.Text == "0")
                {
                    TypeHere.Text = text;
                }
                else
                {
                    TypeHere.Text += text;
                }
            }
        }

        public void AppendDecimalToTextBox()
        {
            if (TypeHere.Text.Length >= MaxDigits)
                return;

            if (!TypeHere.Text.Contains("."))
            {
                if (TypeHere.Text == "0")
                {
                    TypeHere.Text = "0.";
                }
                else
                {
                    TypeHere.Text += ".";
                }
            }
        }

        public void AppendOperationToTextBox(string operation)
        {
            if (_isNewCalculation)
            {
                // If starting a new calculation, use the current value in the TextBox
                _currentExpression = $"{TypeHere.Text} {operation}";
                Expression.Text = _currentExpression;
                _isNewCalculation = false; // Reset the flag
            }
            else
            {
                // Append the current number and operator to the TextBlock
                _currentExpression += $" {TypeHere.Text} {operation}";
                Expression.Text = _currentExpression;
            }

            // Clear the TextBox for the next input
            TypeHere.Text = "0";
        }

        public void EvaluateExpression()
        {
            try
            {
                // Use the current expression directly if it already includes the percentage value
                string expression = _currentExpression.Contains(TypeHere.Text)
                    ? _currentExpression
                    : _currentExpression + " " + TypeHere.Text;

                // Sanitize the expression for evaluation
                string sanitizedExpression = expression.Replace("×", "*").Replace("÷", "/").Trim();
                var result = new DataTable().Compute(sanitizedExpression, null);

                // Update the TextBox with the result
                TypeHere.Text = result.ToString();

                // Reset the state for a new calculation
                _currentExpression = "";
                Expression.Text = "";
                _isNewCalculation = true;
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
                _currentExpression = "";
                Expression.Text = "";
                _isNewCalculation = true;
            }
        }

        private void EvaluatePartialExpression()
        {
            try
            {
                // Append the current value in the TextBox to complete the expression
                _currentExpression += $" {TypeHere.Text}";

                // Sanitize the expression for evaluation
                string sanitizedExpression = _currentExpression.Replace("×", "*").Replace("÷", "/").Trim();
                var result = new DataTable().Compute(sanitizedExpression, null);

                // Update the TextBox with the result
                TypeHere.Text = result.ToString();

                // Update the current expression to reflect the result
                _currentExpression = $"{result}";
                Expression.Text = _currentExpression;
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
                _currentExpression = "";
                Expression.Text = "";
                _isNewCalculation = true;
            }
        }

        public void CalculateSin()
        {
            try
            {
                double value = ConvertToRadians(Convert.ToDouble(TypeHere.Text));
                TypeHere.Text = Math.Sin(value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void CalculateCos()
        {
            try
            {
                double value = ConvertToRadians(Convert.ToDouble(TypeHere.Text));
                TypeHere.Text = Math.Cos(value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void CalculateTan()
        {
            try
            {
                double value = ConvertToRadians(Convert.ToDouble(TypeHere.Text));
                double result = Math.Tan(value);

                // Handle undefined results (e.g., tan(90°))
                if (double.IsInfinity(result))
                {
                    TypeHere.Text = "Undefined";
                }
                else
                {
                    TypeHere.Text = result.ToString();
                }
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void CalculateSec()
        {
            try
            {
                double value = ConvertToRadians(Convert.ToDouble(TypeHere.Text));
                double result = 1 / Math.Cos(value);

                // Handle undefined results (e.g., sec(90°))
                if (double.IsInfinity(result))
                {
                    TypeHere.Text = "Undefined";
                }
                else
                {
                    TypeHere.Text = result.ToString();
                }
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void CalculateCsc()
        {
            try
            {
                double value = ConvertToRadians(Convert.ToDouble(TypeHere.Text));
                double result = 1 / Math.Sin(value);

                // Handle undefined results (e.g., csc(0°))
                if (double.IsInfinity(result))
                {
                    TypeHere.Text = "Undefined";
                }
                else
                {
                    TypeHere.Text = result.ToString();
                }
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void CalculateCot()
        {
            try
            {
                double value = ConvertToRadians(Convert.ToDouble(TypeHere.Text));
                double result = 1 / Math.Tan(value);

                // Handle undefined results (e.g., cot(0°))
                if (double.IsInfinity(result))
                {
                    TypeHere.Text = "Undefined";
                }
                else
                {
                    TypeHere.Text = result.ToString();
                }
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }
        private double ConvertToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public void Backspace()
        {
            if (TypeHere.Text.Length > 0)
            {
                TypeHere.Text = TypeHere.Text.Substring(0, TypeHere.Text.Length - 1);
                if (TypeHere.Text.Length == 0)
                {
                    TypeHere.Text = "0";
                }
            }
        }

        public void ClearEntry()
        {
            TypeHere.Text = "0";
        }

        public void ClearAll()
        {
            TypeHere.Text = "0";
            Expression.Text = "";
            _currentExpression = "";
            _isNewCalculation = true;
        }

        public void AppendOpenParenthesis()
        {
            AppendToTextBox("(");
        }

        public void AppendCloseParenthesis()
        {
            AppendToTextBox(")");
        }

        public void CalculateSquareRoot()
        {
            try
            {
                double value = Convert.ToDouble(TypeHere.Text);
                TypeHere.Text = Math.Sqrt(value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void CalculateExponentiation()
        {
            try
            {
                string expression = TypeHere.Text.Replace(" ", "");
                string[] parts = expression.Split('^');
                if (parts.Length == 2)
                {
                    double baseValue = Convert.ToDouble(parts[0]);
                    double exponent = Convert.ToDouble(parts[1]);
                    TypeHere.Text = Math.Pow(baseValue, exponent).ToString();
                }
                else
                {
                    TypeHere.Text = "Error";
                }
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }
        public void CalculatePercentage()
        {
            try
            {
                // Split the current expression into parts
                string[] parts = _currentExpression.Trim().Split(' ');

                if (parts.Length < 2)
                {
                    // If there's no operator or first number, do nothing
                    return;
                }

                double firstNumber = Convert.ToDouble(parts[0]);
                string operation = parts[1];

                // Calculate the percentage value
                double percentage = Convert.ToDouble(TypeHere.Text) / 100;

                double result = operation switch
                {
                    "+" => firstNumber * percentage, // Add percentage of the first number
                    "-" => firstNumber * percentage, // Subtract percentage of the first number
                    "×" or "*" => firstNumber * percentage, // Multiply first number by (percent / 100)
                    "÷" or "/" => firstNumber / percentage, // Divide first number by (percent / 100)
                    _ => throw new InvalidOperationException("Unsupported operation")
                };

                // Update the TextBlock with the calculated percentage
                _currentExpression = $"{parts[0]} {operation} {result}";
                Expression.Text = _currentExpression;

                // Update the TextBox with the calculated percentage
                TypeHere.Text = result.ToString();

                // Do not reset _isNewCalculation here, as we want to allow further operations
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
                _currentExpression = "";
                Expression.Text = "";
                _isNewCalculation = true;
            }
        }

        public void CalculateSquare()
        {
            try
            {
                double value = Convert.ToDouble(TypeHere.Text);
                TypeHere.Text = Math.Pow(value, 2).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void CalculateTenPowerX()
        {
            try
            {
                double value = Convert.ToDouble(TypeHere.Text);
                TypeHere.Text = Math.Pow(10, value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void CalculateLogarithm()
        {
            try
            {
                double value = Convert.ToDouble(TypeHere.Text);
                TypeHere.Text = Math.Log10(value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void CalculateNaturalLog()
        {
            try
            {
                double value = Convert.ToDouble(TypeHere.Text);
                TypeHere.Text = Math.Log(value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void InsertPi()
        {
            TypeHere.Text = Math.PI.ToString();
        }

        public void CalculateReciprocal()
        {
            try
            {
                double value = Convert.ToDouble(TypeHere.Text);
                TypeHere.Text = (1 / value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }

        public void InsertEulers()
        {
            TypeHere.Text = Math.E.ToString();
        }

        public void CalculateAbsoluteValue()
        {
            try
            {
                double value = Convert.ToDouble(TypeHere.Text);
                TypeHere.Text = Math.Abs(value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }
        private bool IsLastCharacterOperator()
        {
            if (string.IsNullOrEmpty(TypeHere.Text))
                return false;

            string trimmedText = TypeHere.Text.TrimEnd();
            char lastChar = trimmedText[^1];
            return lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/';
        }

        private string HandleExponentiation(string expression)
        {
            while (expression.Contains("^"))
            {
                int index = expression.IndexOf('^');
                int leftIndex = index - 1;
                int rightIndex = index + 1;

                // Find the base value
                while (leftIndex >= 0 && (char.IsDigit(expression[leftIndex]) || expression[leftIndex] == '.'))
                {
                    leftIndex--;
                }
                leftIndex++;

                // Find the exponent value
                while (rightIndex < expression.Length && (char.IsDigit(expression[rightIndex]) || expression[rightIndex] == '.'))
                {
                    rightIndex++;
                }

                double baseValue = Convert.ToDouble(expression.Substring(leftIndex, index - leftIndex));
                double exponent = Convert.ToDouble(expression.Substring(index + 1, rightIndex - index - 1));
                double result = Math.Pow(baseValue, exponent);

                expression = expression.Substring(0, leftIndex) + result.ToString() + expression.Substring(rightIndex);
            }

            return expression;
        }
        public void CalculateExponential()
        {
            try
            {
                double value = Convert.ToDouble(TypeHere.Text);
                TypeHere.Text = Math.Exp(value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }
        public void CalculateFactorial()
        {
            try
            {
                int value = Convert.ToInt32(TypeHere.Text);
                TypeHere.Text = Factorial(value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }
        private int Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }
        public void FlipSign()
        {
            try
            {
                double value = Convert.ToDouble(TypeHere.Text);
                TypeHere.Text = (-value).ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }
        public void CalculateModulus()
        {
            try
            {
                string[] parts = TypeHere.Text.Split(new char[] { '%' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    double left = Convert.ToDouble(parts[0]);
                    double right = Convert.ToDouble(parts[1]);
                    TypeHere.Text = (left % right).ToString();
                }
                else
                {
                    TypeHere.Text = "Error";
                }
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
        }
    }
}
