using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using Electronika.Commands;
using Electronika.Models;
using Electronika.Views;


namespace Electronika.ViewModels
{
    class SettingsViewModel : INotifyPropertyChanged
    {

        private Config _config = new Config();
        private ICommand _exitCommand;
        private ICommand _loadedCommand;
        private ICommand _ltKeyCommand;
        private ICommand _lbKeyCommand;
        private ICommand _rtKeyCommand;
        private ICommand _rbKeyCommand;
        private ICommand _saveCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public Config config
        {
            get
            {
                return _config;
            }
            set
            {
                _config = value;
                OnPropertyChanged("config");
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand
                 ?? (_exitCommand = new ActionCommand(() =>
                 {
                     Settings singleOrDefault = (Settings)App.Current.Windows.OfType
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
                     Settings singleOrDefault = (Settings)App.Current.Windows.OfType
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

        public ICommand LTKeyCommand
        {
            get
            {
                return _ltKeyCommand
                 ?? (_ltKeyCommand = new Command((obj) =>
                 {
                     KeyEventArgs k = obj as KeyEventArgs;
                     if (KeyIsUnique(k.Key.ToString()))
                     {
                         config.WolfLTKey = k.Key.ToString();

                     }
                     else 
                     {
                         CustomMessageBox messageBox = new CustomMessageBox($"Key {k.Key.ToString()} is alredy used");
                         messageBox.ShowDialog();
                     }
                 }));
            }
        }

        public ICommand LBKeyCommand
        {
            get
            {
                return _lbKeyCommand
                 ?? (_lbKeyCommand = new Command((obj) =>
                 {
                     KeyEventArgs k = obj as KeyEventArgs;
                     if (KeyIsUnique(k.Key.ToString()))
                     {
                         config.WolfLBKey = k.Key.ToString();
                     }
                     else
                     {
                         CustomMessageBox messageBox = new CustomMessageBox($"Key {k.Key.ToString()} is alredy used");
                         messageBox.ShowDialog();
                     }
                 }));
            }
        }

        public ICommand RTKeyCommand
        {
            get
            {
                return _rtKeyCommand
                 ?? (_rtKeyCommand = new Command((obj) =>
                 {
                     KeyEventArgs k = obj as KeyEventArgs;
                     if (KeyIsUnique(k.Key.ToString()))
                     {
                         config.WolfRTKey = k.Key.ToString();
                     }
                     else
                     {
                         CustomMessageBox messageBox = new CustomMessageBox($"Key {k.Key.ToString()} is alredy used");
                         messageBox.ShowDialog();
                     }
                 }));
            }
        }

        public ICommand RBKeyCommand
        {
            get
            {
                return _rbKeyCommand
                 ?? (_rbKeyCommand = new Command((obj) =>
                 {
                     KeyEventArgs k = obj as KeyEventArgs;
                    if(KeyIsUnique(k.Key.ToString())) 
                     {
                     config.WolfRBKey = k.Key.ToString();
                     }
                     else
                     {
                         CustomMessageBox messageBox = new CustomMessageBox($"Key {k.Key.ToString()} is alredy used");
                         messageBox.ShowDialog();
                     }

                 }));
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand
                 ?? (_saveCommand = new ActionCommand(() =>
                 {
                     MySerializer.SerializeXml<Config>(_config, "config.cfg");
                     Settings singleOrDefault = (Settings)App.Current.Windows.OfType
                     <System.Windows.Window>().SingleOrDefault(x => x.IsActive);
                     singleOrDefault.Close();
                 }));
            }
        }

        public SettingsViewModel(Config cfg)
        {

         _config = cfg;

        }
        private bool KeyIsUnique(string key)
        {
            if (config.WolfLTKey == key)
            {
                return false;
            }
            else if (config.WolfLBKey == key)
            {
                return false;

            }
            else if (config.WolfRTKey == key)
            {
                return false;
            }
            else if (config.WolfRBKey == key) 
            {
                return false;
            }
            return true;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
