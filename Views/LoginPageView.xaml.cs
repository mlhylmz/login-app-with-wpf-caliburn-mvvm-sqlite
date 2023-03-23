using System.Windows;
using System.Windows.Input;

namespace LoginApp.Views
{
    /// <summary>
    /// LoginPageView.xaml etkileşim mantığı
    /// </summary>
    public partial class LoginPageView : Window
    {
        public LoginPageView()
        {
            InitializeComponent();
        }

        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
