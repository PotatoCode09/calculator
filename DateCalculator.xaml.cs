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
    /// Interaction logic for DateCalculator.xaml
    /// </summary>
    public partial class DateCalculator : Page
    {
        Page dtDBD;
        Page dtAddSub;

        public DateCalculator()
        {
            InitializeComponent();
            dtDBD = new DateCalculatorDBD();
            dtAddSub = new DateCalculatorAddSubtract();
            LoadDateCalculatorPage("DBD");
        }
        public void DBD_Selected(object sender, RoutedEventArgs e)
        {
            LoadDateCalculatorPage("DBD");
        }

        public void AddSub_Selected(object sender, RoutedEventArgs e)
        {
            LoadDateCalculatorPage("AddSub");
        }

        public void LoadDateCalculatorPage(string pageType)
        {
            if (pageType == "DBD")
            {
                DateCalcMode.Navigate(dtDBD);
            }
            else if (pageType == "AddSub")
            {
                DateCalcMode.Navigate(dtAddSub);
            }
        }
    }
}