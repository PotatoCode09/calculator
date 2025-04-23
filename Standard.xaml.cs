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
    /// Interaction logic for Standard.xaml
    /// </summary>
    public partial class Standard : Page
    {
        public Standard()
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

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculatePercentage();
        }

        private void SquareRootButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateSquareRoot();
        }

        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateSquare();
        }

        private void ReciprocalButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.CalculateReciprocal();
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.Backspace();
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.FlipSign();
        }

        private void ClearEntryButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.ClearEntry();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NumericalCals.Instance.ClearAll();
        }
    }
}
