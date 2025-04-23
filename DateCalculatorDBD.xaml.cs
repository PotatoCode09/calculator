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
    /// Interaction logic for DateCalculatorDBD.xaml
    /// </summary>
    public partial class DateCalculatorDBD : Page
    {
        public DateCalculatorDBD()
        {
            InitializeComponent();
            StartingDate.SelectedDateChanged += OnDateChanged;
            EndDate.SelectedDateChanged += OnDateChanged;
        }
        private void OnDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ensure both dates are selected
            if (StartingDate.SelectedDate.HasValue && EndDate.SelectedDate.HasValue)
            {
                DateTime startDate = StartingDate.SelectedDate.Value;
                DateTime endDate = EndDate.SelectedDate.Value;

                // Calculate the absolute difference
                if (startDate > endDate)
                {
                    (startDate, endDate) = (endDate, startDate); // Swap dates if startDate is later
                }

                // Calculate the difference
                TimeSpan difference = endDate - startDate;

                // Calculate years, months, and days
                int years = endDate.Year - startDate.Year;
                int months = endDate.Month - startDate.Month;
                int days = endDate.Day - startDate.Day;

                // Adjust for negative days or months
                if (days < 0)
                {
                    months--;
                    days += DateTime.DaysInMonth(startDate.Year, startDate.Month);
                }

                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                // Display the result
                Answer.Text = $"{years} years, {months} months, {days} days";
            }
            else
            {
                // Clear the result if one or both dates are not selected
                Answer.Text = "Please select both dates.";
            }
        }
    }
}
