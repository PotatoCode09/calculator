using System;
using System.Collections.Generic;
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
    /// Interaction logic for Programmer.xaml
    /// </summary>
    public partial class Programmer : Page
    {
        private string _currentOperation = string.Empty; // Tracks the current operation (+, -, *, /)
        private long _firstOperand = 0; // Stores the first operand
        private int _currentBase = 10; // Tracks the current number system (2, 8, 10, 16)


        public Programmer()
        {
            InitializeComponent();
        }

        /// <param name = "value" > The decimal value to convert.</param>
        public void UpdateConversions(string value)
        {
            try
            {
                if (long.TryParse(value, out long decimalValue))
                {
                    HD.Text = $"{decimalValue:X}"; // Hexadecimal
                    DC.Text = $"{decimalValue}";  // Decimal
                    OC.Text = $"{Convert.ToString(decimalValue, 8)}"; // Octal
                    BN.Text = $"{Convert.ToString(decimalValue, 2)}"; // Binary
                }
                else
                {
                    HD.Text = "Invalid";
                    DC.Text = "Invalid";
                    OC.Text = "Invalid";
                    BN.Text = "Invalid";
                }
            }
            catch
            {
                HD.Text = "Error";
                DC.Text = "Error";
                OC.Text = "OCT: Error";
                BN.Text = "BIN: Error";
            }
        }

        private void Hex_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.SetBase(16);
        }

        private void Dec_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.SetBase(10);
        }

        private void Oct_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.SetBase(8);
        }

        private void Bin_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.SetBase(2);
        }

        private void SetBase(int newBase)
        {
            try
            {
                _currentBase = newBase;
                UpdateConversions(DC.Text); // Update all number system displays
            }
            catch
            {
                MessageBox.Show("Error switching base.");
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string number = button.Content.ToString();

                // Append the number to the current value
                if (NumericalCals.Instance.TypeHere.Text == "0" || _currentOperation == "=")
                {
                    NumericalCals.Instance.TypeHere.Text = number;
                }
                else
                {
                    NumericalCals.Instance.TypeHere.Text += number;
                }

                // Update the Expression TextBlock
                NumericalCals.Instance.Expression.Text = NumericalCals.Instance.TypeHere.Text;
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string operation = button.Content.ToString();

                if (long.TryParse(NumericalCals.Instance.TypeHere.Text, out long value))
                {
                    _firstOperand = value;
                    _currentOperation = operation;
                    NumericalCals.Instance.Expression.Text = $"{_firstOperand} {operation}";
                    NumericalCals.Instance.TypeHere.Text = "0"; // Clear the display for the second operand
                }
            }
        }

        private void EvaluateButton_Click(object sender, RoutedEventArgs e)
        {
            if (long.TryParse(NumericalCals.Instance.TypeHere.Text, out long secondOperand))
            {
                long result = 0;

                try
                {
                    switch (_currentOperation)
                    {
                        case "+":
                            result = _firstOperand + secondOperand;
                            break;
                        case "-":
                            result = _firstOperand - secondOperand;
                            break;
                        case "*":
                            result = _firstOperand * secondOperand;
                            break;
                        case "/":
                            if (secondOperand == 0)
                            {
                                MessageBox.Show("Cannot divide by zero.");
                                return;
                            }
                            result = _firstOperand / secondOperand;
                            break;
                        default:
                            MessageBox.Show("Invalid operation.");
                            return;
                    }

                    // Update the TextBox and TextBlock
                    NumericalCals.Instance.TypeHere.Text = result.ToString();
                    NumericalCals.Instance.Expression.Text = $"{_firstOperand} {_currentOperation} {secondOperand} = {result}";
                    _currentOperation = "="; // Mark the operation as complete
                }
                catch
                {
                    MessageBox.Show("Error performing calculation.");
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the first operand and current operation
            _firstOperand = 0;
            _currentOperation = string.Empty;

            // Clear the NumericalCals instance (TextBox and TextBlock)
            NumericalCals.Instance.ClearAll();

            // Optionally, reset the Programmer-specific fields
            DC.Text = "0";
            UpdateConversions(DC.Text);
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (DC.Text.Length > 1)
            {
                DC.Text = DC.Text.Substring(0, DC.Text.Length - 1);
            }
            else
            {
                DC.Text = "0";
            }

            UpdateConversions(DC.Text);
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            if (long.TryParse(DC.Text, out long value))
            {
                DC.Text = (-value).ToString();
                UpdateConversions(DC.Text);
            }
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DC.Text.Contains("."))
            {
                DC.Text += ".";
            }
        }
    }
}
