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

        public NumericalCals()
        {
            InitializeComponent();
            Instance = this;  // Set instance
        }

        public void LoadCalculatorPage(Page calculatorPage)
        {
            SecondaryFrame.Navigate(calculatorPage);
        }

        public void AppendToTextBox(string text)
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
            if (TypeHere.Text.Length >= MaxDigits)
                return;

            if (!string.IsNullOrEmpty(TypeHere.Text) && !IsLastCharacterOperator())
            {
                TypeHere.Text += $" {operation} ";
            }
        }

        public void EvaluateExpression()
        {
            try
            {
                string expression = TypeHere.Text.Replace(" ", "");
                expression = HandleExponentiation(expression);
                var result = new DataTable().Compute(expression, null);
                TypeHere.Text = result.ToString();
            }
            catch (Exception)
            {
                TypeHere.Text = "Error";
            }
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

        public void ClearEverything()
        {
            TypeHere.Text = "0";
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

            char lastChar = TypeHere.Text[^1];
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
