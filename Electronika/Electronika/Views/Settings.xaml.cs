using Electronika.Models;
using Electronika.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Electronika.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        public Settings(Config cfg)
        {

            InitializeComponent();
            DataContext = new SettingsViewModel(cfg);
   
        }

    


    }
}
