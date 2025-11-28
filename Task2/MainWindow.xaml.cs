using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object x;

        public MainWindow()
        {
            InitializeComponent();
            //Start with buttons disabled until inputs are valid
            SetOperatorButtonsEnabled(false);
            txtA.Focus();

        }

        private void SetOperatorButtonsEnabled(bool enabled)
        {
            btnAdd.IsEnabled = enabled;
            btnSub.IsEnabled = enabled;
            btnMul.IsEnabled = enabled;
            btnDiv.IsEnabled = enabled;

        }
        private bool TryGetInputs(out double a, out double b)
        {
            //Use InvariantCulture so "." works regardless of system locale.
            var style = NumberStyles.Float | NumberStyles.AllowThousands;
            var culture = CultureInfo.InvariantCulture;

            bool okA = double.TryParse(txtA.Text?.Trim(),style,culture, out a);
            bool okB = double.TryParse(txtB.Text?.Trim(), style, culture, out b);

            return okA && okB;
        }
        private void ShowResult(double value)
        {
            txtResult.Text = value.ToString(CultureInfo.InvariantCulture);
        }
        private void AnyInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Enable operator buttons only if both inputs are valid numbers
            SetOperatorButtonsEnabled(TryGetInputs(out _, out _));
            txtResult.Text = string.Empty;//Clear previous result on edit 
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetInputs(out double a , out double b))
            {
                MessageBox.Show("Pleasa type valid number in both inputs.", "Validation",MessageBoxButton.OK, MessageBoxImage.Warning);
                
                return;
            }
            ShowResult(a + b);
        }
        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetInputs(out double a, out double b))
            {
                MessageBox.Show("Pleasa type valid number in both inputs.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;

            }
            ShowResult(a - b);
        }

        private void btnMul_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetInputs (out double a , out double b))
            {
                MessageBox.Show("Pleasa type valid number in both inputs.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;

            }
            ShowResult(a * b);
        }
        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            if(!TryGetInputs (out double a ,out double b))
            {
                MessageBox.Show("Pleasa type valid number in both inputs.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(Math.Abs(b)<double.Epsilon)
            {
                MessageBox.Show("Cannot divide by zero.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            ShowResult(a / b);
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = string.Empty;
            txtB.Text = string.Empty;
            txtResult.Text = string.Empty;
            txtA.Focus();
        }




    }
}