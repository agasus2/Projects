using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

using Electronika.Models;
using Electronika.Views;
using Electronika.Commands;
using System.Xml;
using System.Windows;
using System;

namespace Electronika.ViewModels
{
    class LeaderBordViewModel : INotifyPropertyChanged
    {
        private ICommand _okCommand;
        private ICommand _loadedommand;
        private Config _config = new Config();

        public event PropertyChangedEventHandler PropertyChanged;
        public List<Score> Scores { get; set; }

        public ICommand OKCommand
        {
            get
            {
                return _okCommand
                 ?? (_okCommand = new ActionCommand(() =>
                 {
                     LeaderBord singleOrDefault = (LeaderBord)App.Current.Windows.OfType
                     <System.Windows.Window>().SingleOrDefault(x => x.IsActive);
                     singleOrDefault.Close();

                 }));
            }
        }

        public ICommand LoadedCommand
        {
            get
            {
                return _loadedommand
                 ?? (_loadedommand = new ActionCommand(() =>
                 {
                     LeaderBord singleOrDefault = (LeaderBord)App.Current.Windows.OfType
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

        public LeaderBordViewModel(Config cfg)
        {
            if (File.Exists("LeaderBord.ldr"))
            {
                try
                {
                    Scores = MySerializer.DeserializeXml<List<Score>>("LeaderBord.ldr");
                }
                catch (InvalidOperationException)
                {
                    Scores = Score.GetDeffaultScoreList();
                    CustomMessageBox messageBox = new CustomMessageBox("File LeaderBord.ldr is damaged. Reset to default leader bord");
                    messageBox.ShowDialog();
              
                    MySerializer.SerializeXml<List<Score>>(Scores, "LeaderBord.ldr");
                }
            }

            else
            {
                Scores = Score.GetDeffaultScoreList();

            }
            Scores.Sort();
            Scores.Reverse();

            _config = cfg;
          
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
