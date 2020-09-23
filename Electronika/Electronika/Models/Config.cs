using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Electronika.Models
{
    [Serializable]
    public class Config : INotifyPropertyChanged
    {
        private double _gameSpeed;
        private bool _fullScreen;
        private Key _wolfLTKey;
        private Key _wolfLBKey;
        private Key _wolfRTKey;
        private Key _wolfRBKey;

        public event PropertyChangedEventHandler PropertyChanged;

        public double GameSpeed
        {
            get
            {
                return _gameSpeed;
            }
            set
            {
                _gameSpeed = value;
                OnPropertyChanged("GameSpeed");
            }
        }

        public void SetDeffault()
        {
            _gameSpeed = 2.0;
            _fullScreen = false;
            _wolfLTKey = Key.Q;
            _wolfLBKey = Key.A;
            _wolfRTKey = Key.E;
            _wolfRBKey = Key.D;
        }
        public bool FullScreen
        {
            get
            {
                return _fullScreen;
            }
            set
            {
                _fullScreen = value;
                OnPropertyChanged("FullScreen");
            }
        }

        public string WolfLTKey
        {
            get
            {
                return _wolfLTKey.ToString();
            }
            set
            {
                _wolfLTKey = (Key)Enum.Parse(typeof(Key), value);
                OnPropertyChanged("WolfLTKey");
            }
        }

        public string WolfLBKey
        {
            get
            {
                return _wolfLBKey.ToString();
            }
            set
            {
                _wolfLBKey = (Key)Enum.Parse(typeof(Key), value);
                OnPropertyChanged("WolfLBKey");
            }
        }

        public string WolfRTKey
        {
            get
            {
                return _wolfRTKey.ToString();
            }
            set
            {
                _wolfRTKey = (Key)Enum.Parse(typeof(Key), value);
                OnPropertyChanged("WolfRTKey");
            }
        }

        public string WolfRBKey
        {
            get
            {
                return _wolfRBKey.ToString();
            }
            set
            {
                _wolfRBKey = (Key)Enum.Parse(typeof(Key), value);
                OnPropertyChanged("WolfRBKey");
            }
        }

        public Config()
        {

        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
