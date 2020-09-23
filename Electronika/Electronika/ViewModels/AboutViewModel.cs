using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using Electronika.Commands;
using Electronika.Models;
using Electronika.Views;


namespace Electronika.ViewModels
{
    class AboutViewModel :INotifyPropertyChanged
    {
        private ICommand _loadedCommand;
        private Config _config = new Config();
        private ImageSource _leftWolf = new BitmapImage (
            new Uri("pack://application:,,,/Resources/WolfRT.png"));
        private string _descriprion = Properties.Resources.Description;
        private ICommand _okCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Description 
        {
            get
            {
                return _descriprion;
            }
            set
            {
                _descriprion = value;
                OnPropertyChanged("Description");
            }
        }

        public ImageSource LeftWolf
        {
            get
            {
                return _leftWolf;
            }
            set
            {
                _leftWolf = value;
                OnPropertyChanged("LeftWolf");
            }
        }

        public AboutViewModel(Config cfg)
        {
            _config = cfg;
        }

        public ICommand OKCommand
        {
            get
            {
                return _okCommand
                 ?? (_okCommand = new ActionCommand(() =>
                 {
                     About singleOrDefault = (About)App.Current.Windows.OfType
                     <System.Windows.Window>().SingleOrDefault(x => x.IsActive);
                
                     singleOrDefault.Close();

                 }));
            }
        }

        public ICommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                 ?? (_loadedCommand = new ActionCommand(() =>
                 {
                    
                     About singleOrDefault = (About)App.Current.Windows.OfType
                    <System.Windows.Window>().SingleOrDefault(x => x.IsActive);

                     if (_config.FullScreen)
                     {
                         singleOrDefault.WindowState = System.Windows.WindowState.Maximized;
                     }
                     else
                     {
                         singleOrDefault.WindowState = System.Windows.WindowState.Normal;
                     }
                 }));
            }
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
