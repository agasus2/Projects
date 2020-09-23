using System.Windows;

using Electronika.ViewModels;

namespace Electronika.Views
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        public GameOver(int score)
        {
            InitializeComponent();
            DataContext = new GameOverViewModel(score);
        }
    }
}
