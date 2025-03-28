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
            MainFrame.Navigate(new NumericalCals());
            //MainFrame.Navigate(new DateCalculator());
        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (isSidebarOpen)
            {
                // Hide the sidebar
                DoubleAnimation hideSidebar = new DoubleAnimation();
                hideSidebar.To = -200;
                hideSidebar.Duration = TimeSpan.FromSeconds(0.3);
                SidebarTransform.BeginAnimation(TranslateTransform.XProperty, hideSidebar);
            }
            else
            {
                // Show sidebar
                DoubleAnimation showAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.3));
                SidebarTransform.BeginAnimation(TranslateTransform.XProperty, showAnimation);
            }

            isSidebarOpen = !isSidebarOpen;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Slide the sidebar out (hide it)
            DoubleAnimation slideOut = new DoubleAnimation();
            slideOut.To = -200;
            slideOut.Duration = TimeSpan.FromSeconds(0.3);
            SidebarTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);

            // Update state variable to reflect sidebar is hidden
            isSidebarOpen = false;
        }

        private void LoadStandard(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(numCals); // Ensure it goes to NumericalCals first
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
