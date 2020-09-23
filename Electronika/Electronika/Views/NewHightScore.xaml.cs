using System.Windows;

using Electronika.ViewModels;

namespace Electronika.Views
{
    /// <summary>
    /// Interaction logic for NewHightScore.xaml
    /// </summary>
    public partial class NewHightScore : Window
    {
        public NewHightScore()
        {
            InitializeComponent();
            DataContext = new NewHightScoreViewModel();
        }
    }
}
