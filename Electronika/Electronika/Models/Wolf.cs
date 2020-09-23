using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Electronika.Enums;

namespace Electronika.Models
{
   public class Wolf : INotifyPropertyChanged
    {
        private ImageSource _wolfSource ;
        private Visibility _wolfVisibility = Visibility.Visible;

        public Position Position;
        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource WolfSource 
        {
            get 
            {
                return _wolfSource;
            }
            set 
            {
                _wolfSource = value;
                OnPropertyChanged("WolfSource");
            }
        }

        public Visibility WolfVisibility 
        {
            get 
            {
                return _wolfVisibility;
            }
            set 
            {
                _wolfVisibility = value;
                OnPropertyChanged("WolfVisibility");
            }
        }

        public Wolf(Uri location, Position pos)
        {
            WolfSource = new BitmapImage(location);
            Position = pos;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
