using Electronika.Models;
using Electronika.ViewModels;

using System.Windows;

namespace Electronika.Views
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About(Config cfg)
        {
            InitializeComponent();
            DataContext = new AboutViewModel(cfg);
        }
    }
}
