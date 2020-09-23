using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Electronika.Commands;
using Electronika.Models;
using Electronika.Views;


namespace Electronika.ViewModels
{
    class MenuViewModel : INotifyPropertyChanged
    {
        private Config _config = new Config();
        private ICommand _playCommand;
        private ICommand _settingsCommand;
        private ICommand _loadedAndActivatedCommand;
        private ICommand _leaderBordCommand;
        private ICommand _aboutCommand;
        private ICommand _exitCommand;
        private ImageSource _leftWolf = new BitmapImage(
            new Uri("pack://application:,,,/Resources/WolfRT.png"));
        private ImageSource _leftEgg = new BitmapImage(
            new Uri("pack://application:,,,/Resources/RTEggSpawn/RightEggPos5.png"));
        private ImageSource _rightrWolf = new BitmapImage(
            new Uri("pack://application:,,,/Resources/WolfLT.png"));
        private ImageSource _rightEgg = new BitmapImage(
            new Uri("pack://application:,,,/Resources/LTEggSpawn/LeftEggPos5.png"));

        public event PropertyChangedEventHandler PropertyChanged;

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

        public ImageSource LeftEgg
        {
            get
            {
                return _leftEgg;
            }
            set
            {
                _leftEgg = value;
                OnPropertyChanged("LeftEgg");
            }
        }
     
        public ImageSource RightWolf
        {
            get
            {
                return _rightrWolf;
            }
            set
            {
                _rightrWolf = value;
                OnPropertyChanged("RightWolf");
            }
        }
     
        public ImageSource RightEgg
        {
            get
            {
                return _rightEgg;
            }
            set
            {
                _rightEgg = value;
                OnPropertyChanged("RightEgg");
            }
        }

        public ICommand PlayCommand
        {
            get
            {
                return _playCommand
                 ?? (_playCommand = new ActionCommand(() =>
                 {
                     Game main = new Game(_config);
                     App.Current.MainWindow.Hide();
                     main.ShowDialog();
                     App.Current.MainWindow.Show();

                 }));
            }
        }

        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand
                 ?? (_settingsCommand = new ActionCommand(() =>
                 {
                     Settings settings = new Settings(_config);
                     App.Current.MainWindow.Hide();
                     settings.ShowDialog();
                     App.Current.MainWindow.Show();

                 }));
            }
        }

        public ICommand LoadedAndActivatedCommand
        {
            get
            {
                return _loadedAndActivatedCommand
                 ?? (_loadedAndActivatedCommand = new ActionCommand(() =>
                 {
                     LoadSettings();

                     if (_config.FullScreen)
                     {
                         App.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
                     }
                     else 
                     {
                         App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
                     }
                 }));
            }
        }

        public ICommand LeaderBordCommand
        {
            get
            {
                return _leaderBordCommand
                 ?? (_leaderBordCommand = new ActionCommand(() =>
                 {
                     LeaderBord leaderBord = new LeaderBord(_config);
                     App.Current.MainWindow.Hide();
                     leaderBord.ShowDialog();
                     App.Current.MainWindow.Show();
                 }));
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return _aboutCommand
                 ?? (_aboutCommand = new ActionCommand(() =>
                 {
                     About about = new About(_config);
                     App.Current.MainWindow.Hide();
                     about.ShowDialog();
                     App.Current.MainWindow.Show();

                 }));
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand
                 ?? (_exitCommand = new ActionCommand(() =>
                 {
                   App.Current.MainWindow.Close();
                 }));
            }
        }

        private void LoadSettings() 
        {
            if (File.Exists($"config.cfg"))
            {
                try
                {
                    _config = MySerializer.DeserializeXml<Config>("config.cfg");
                }
                catch (InvalidOperationException)
                {
                    _config.SetDeffault();
                    
                    CustomMessageBox messageBox = new CustomMessageBox("File config.cfg is damaged. Reset to default settings");
                    messageBox.ShowDialog();
                    MySerializer.SerializeXml<Config>(_config, "config.cfg");
                }
            }
            else 
            {
                _config.SetDeffault();
            }
        }

        public MenuViewModel()
        {
            LoadSettings();
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
