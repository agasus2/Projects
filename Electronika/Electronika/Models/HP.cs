using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Electronika.Models
{
   public class HP : INotifyPropertyChanged
    {
        private ImageSource _hp1Source;
        private ImageSource _hp2Source;
        private ImageSource _hp3Source;
        private Visibility _hp1SourceVisibility = Visibility.Hidden;
        private Visibility _hp2SourceVisibility = Visibility.Hidden;
        private Visibility _hp3SourceVisibility = Visibility.Hidden;

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource HP1Source
        {
            get
            {
                return _hp1Source;
            }
            set
            {
                _hp1Source = value;
                OnPropertyChanged("HP1Source");
            }
        }

        public ImageSource HP2Source
        {
            get
            {
                return _hp2Source;
            }
            set
            {
                _hp2Source = value;
                OnPropertyChanged("HP2Source");
            }
        }
     
        public ImageSource HP3Source
        {
            get
            {
                return _hp3Source;
            }
            set
            {
                _hp3Source = value;
                OnPropertyChanged("HP3Source");
            }
        }
    
        public Visibility Hp1Visibility
        {
            get
            {
                return _hp1SourceVisibility;
            }
            set
            {
                _hp1SourceVisibility = value;
                OnPropertyChanged("Hp1Visibility");
            }
        }
   
        public Visibility Hp2Visibility
        {
            get
            {
                return _hp2SourceVisibility;
            }
            set
            {
                _hp2SourceVisibility = value;
                OnPropertyChanged("Hp2Visibility");
            }
        }

        public Visibility Hp3Visibility
        {
            get
            {
                return _hp3SourceVisibility;
            }
            set
            {
                _hp3SourceVisibility = value;
                OnPropertyChanged("Hp3Visibility");
            }
        }

        public HP(Uri hp1Location, Uri hp2Location , Uri hp3Location)
        {
            HP1Source = new BitmapImage(hp1Location);
            HP2Source = new BitmapImage(hp2Location);
            HP3Source = new BitmapImage(hp3Location);
        }

     
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
