using System.Windows;

using Electronika.ViewModels;

namespace Electronika.Views
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message)
        {
            InitializeComponent();
            DataContext = new CustomMessageBoxViewModel(message);
        }
    }
}
