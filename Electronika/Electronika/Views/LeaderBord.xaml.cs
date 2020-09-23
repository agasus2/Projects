using Electronika.Models;
using Electronika.ViewModels;
using System.Windows;

namespace Electronika.Views
{
    /// <summary>
    /// Interaction logic for LeaderBord.xaml
    /// </summary>
    public partial class LeaderBord : Window
    {
        public LeaderBord(Config cfg)
        {
            InitializeComponent();
            DataContext = new LeaderBordViewModel(cfg);
        }
    }
}
