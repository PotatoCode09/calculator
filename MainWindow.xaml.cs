using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page sct;
        Page numCals;
        Page std;
        Page dt;
        Page prg;

        private bool isSidebarOpen = false;
        public MainWindow()
        {
            sct = new Scientific();
            numCals = new NumericalCals();
            std = new Standard();
            dt = new DateCalculator();
            prg = new Programmer();

            InitializeComponent();
            MainFrame.Navigate(numCals);
            NumericalCals.Instance.LoadCalculatorPage(std);
            //MainFrame.Navigate(new DateCalculator());
        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            SidebarMenu.Visibility = (SidebarMenu.Visibility == Visibility.Visible) ?
                              Visibility.Collapsed : Visibility.Visible;
        }

        private void LoadStandard(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(numCals); // Ensure it goes to NumericalCals first
            if (NumericalCals.Instance != null)
            {
                NumericalCals.Instance.LoadCalculatorPage(std); // Load inside SecondaryFrame
            }
            UpdateCalculatorType("Standard");
        }

        private void LoadScientific(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(numCals); // Ensure NumericalCals loads
            if (NumericalCals.Instance != null)
            {
                NumericalCals.Instance.LoadCalculatorPage(sct); // Load inside SecondaryFrame
            }
            UpdateCalculatorType("Scientific");
        }

        private void LoadProgrammer(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(numCals);
            if (NumericalCals.Instance != null)
            {
                NumericalCals.Instance.LoadCalculatorPage(prg);
            }
            UpdateCalculatorType("Programmer");
        }


        private void LoadDateCalculator(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(dt);
            UpdateCalculatorType("Date Calculator");
        }

        public void UpdateCalculatorType(string type)
        {
            CalcType.Content = type;
        }


    }

}
