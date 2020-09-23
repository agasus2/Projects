using Electronika.ViewModels;
using System.Windows;

namespace Electronika.Views
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            DataContext = new MenuViewModel();
        }

    }
}
