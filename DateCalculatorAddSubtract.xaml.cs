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
    /// Interaction logic for DateCalculatorAddSubtract.xaml
    /// </summary>
    public partial class DateCalculatorAddSubtract : Page
    {
        public DateCalculatorAddSubtract()
        {
            InitializeComponent();
        }

        private void OnCalculateClick(object sender, RoutedEventArgs e)
        {
            // Validate Starting Date
            if (!StartingDate.SelectedDate.HasValue)
            {
                ResultDate.Text = "Please select a starting date.";
                return;
            }

            DateTime startDate = StartingDate.SelectedDate.Value;

            // Validate Inputs
            if (!int.TryParse(YearsInput.Text, out int years))
            {
                years = 0; // Default to 0 if input is invalid
            }

            if (!int.TryParse(MonthsInput.Text, out int months))
            {
                months = 0; // Default to 0 if input is invalid
            }

            if (!int.TryParse(DaysInput.Text, out int days))
            {
                days = 0; // Default to 0 if input is invalid
            }

            // Determine whether to add or subtract
            if (Subtract.IsChecked == true)
            {
                years = -years;
                months = -months;
                days = -days;
            }

            // Perform the calculation
            try
            {
                DateTime resultDate = startDate.AddYears(years).AddMonths(months).AddDays(days);
                ResultDate.Text = resultDate.ToString("D"); // Display the resulting date
            }
            catch (Exception ex)
            {
                ResultDate.Text = $"Error: {ex.Message}";
            }
        }
    }
}
