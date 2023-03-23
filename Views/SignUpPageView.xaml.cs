using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace LoginApp.Views;

/// <summary>
///     SignUpPageView.xaml etkileşim mantığı
/// </summary>
public partial class SignUpPageView : Window
{
    public SignUpPageView()
    {
        InitializeComponent();
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        var regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}