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
    /// Interaction logic for NumericalCals.xaml
    /// </summary>
    /// 
    
    public partial class NumericalCals : Page
    {
        public static NumericalCals Instance { get; private set; }
        public NumericalCals()
        {
            InitializeComponent();
            SecondaryFrame.Navigate(new Standard());
            Instance = this;  // Set instance
            LoadCalculatorPage(new Standard()); // Default calculator type

        }

        public void LoadCalculatorPage(Page calculatorPage)
        {
            SecondaryFrame.Navigate(calculatorPage);
        }


    }
}
