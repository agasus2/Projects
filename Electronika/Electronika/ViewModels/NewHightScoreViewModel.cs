using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Electronika.Commands;
using Electronika.EventArguments;
using Electronika.Views;



namespace Electronika.ViewModels
{
    class NewHightScoreViewModel : INotifyPropertyChanged
    {
        private string _leaderName = "EnterYourName"; 
        private ICommand _okCommand;

        public event EventHandler<LeaderNameEventArgs> LeaderNameChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public string LeaderName
        {
            get 
            {
                return _leaderName;
            }
            set 
            {
                _leaderName = value;
                OnPropertyChanged("LeaderName");
            }
        }

        public ICommand OKCommand
        {
            get
            {
                return _okCommand
                 ?? (_okCommand = new ActionCommand(() =>
                 {
                     NewHightScore singleOrDefault = (NewHightScore)App.Current.Windows.OfType
                     <System.Windows.Window>().SingleOrDefault(x => x.IsActive);
                     LeaderNameChanged?.Invoke(this, new LeaderNameEventArgs(_leaderName));
                     singleOrDefault.Close();

                 }));
            }
        }

        public NewHightScoreViewModel()
        {
           
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
