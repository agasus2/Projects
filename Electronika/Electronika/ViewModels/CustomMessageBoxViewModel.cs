using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Electronika.Commands;
using Electronika.Views;
namespace Electronika.ViewModels
{
    class CustomMessageBoxViewModel

    {

        private ICommand _okCommand;
        private string _message ;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public ICommand OKCommand
        {
            get
            {
                return _okCommand
                 ?? (_okCommand = new ActionCommand(() =>
                 {
                     CustomMessageBox singleOrDefault = (CustomMessageBox)App.Current.Windows.OfType
                     <System.Windows.Window>().SingleOrDefault(x => x.IsActive);
                     singleOrDefault.Close();

                 }));
            }
        }

        public CustomMessageBoxViewModel(string message)
        {
            Message = message;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
