using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Electronika.Commands;
using Electronika.Views;

namespace Electronika.ViewModels
{
    class GameOverViewModel : INotifyPropertyChanged
    {
    
        private ICommand _okCommand;
        private int _score = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Score 
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged("Score");
            }
        } 

        public ICommand OKCommand
        {
            get
            {
                return _okCommand
                 ?? (_okCommand = new ActionCommand(() =>
                 {
                     GameOver singleOrDefault = (GameOver)App.Current.Windows.OfType
                     <System.Windows.Window>().SingleOrDefault(x => x.IsActive);
                     singleOrDefault.Close();

                 }));
            }
        }

        public GameOverViewModel(int score)
        {
            Score = score;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    
    
}
