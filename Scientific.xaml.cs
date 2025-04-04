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
    /// Interaction logic for Scientific.xaml
    /// </summary>
    public partial class Scientific : Page
    {
        public Scientific()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string number = button.Content.ToString();
                NumericalCals.Instance.AppendToTextBox(number);
            }
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.AppendDecimalToTextBox();
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string operation = button.Content.ToString();
                NumericalCals.Instance.AppendOperationToTextBox(operation);
            }
        }

        private void EvaluateButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.EvaluateExpression();
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.Backspace();
        }
        private void ClearEverythingButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.ClearEverything();
        }

        private void SquareRootButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateSquareRoot();
        }

        private void OpenParenthesisButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.AppendOpenParenthesis();
        }
        private void CloseParenthesisButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.AppendCloseParenthesis();
        }

        private void ExponentiationButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.AppendOperationToTextBox("^");
        }
        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateSquare();
        }
        private void TenPowerXButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateTenPowerX();
        }
        private void LogarithmButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateLogarithm();
        }
        private void NaturalLogButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateNaturalLog();
        }
        private void PiButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.InsertPi();
        }

        private void ReciprocalButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateReciprocal();
        }
        private void EulersButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.InsertEulers();
        }
        private void ExponentialButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateExponential();
        }
        private void AbsoluteValueButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateAbsoluteValue();
        }
        private void FactorialButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateFactorial();
        }
        private void ModulusButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.AppendOperationToTextBox("%");
        }
        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.FlipSign();
        }
    }
}
