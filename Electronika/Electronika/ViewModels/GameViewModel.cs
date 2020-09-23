using System;
using System.Collections.Generic;
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
using Electronika.Enums;
using Electronika.EventArguments;
using Electronika.Models;
using Electronika.Views;


namespace Electronika.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        #region Fields
        private ICommand _loadedCommand;
        private ICommand _windowsClosing;
        private ICommand _ltCommand;
        private ICommand _lbCommand;
        private ICommand _rtCommand;
        private ICommand _rbCommand;
        private ICommand _closeCommand;
        private Wolf _currWolf; 
        private string _leaderName = "";
        private Config _config = new Config();
        private Wolf _wolfLB = new Wolf(
            new Uri("pack://application:,,,/Resources/WolfLB.png"), 
            Position.LeftBottom);
        private Wolf _wolfLT = new Wolf(
            new Uri("pack://application:,,,/Resources/WolfLT.png"),
            Position.LeftTop);
        private Wolf _wolfRB = new Wolf(
            new Uri("pack://application:,,,/Resources/WolfRB.png"), 
            Position.RightBottom);
        private Wolf _wolfRT = 
            new Wolf(new Uri("pack://application:,,,/Resources/WolfRT.png"), Position.RightTop);
        private HP _hp = new HP(
           new Uri("pack://application:,,,/Resources/HP1.png"),
           new Uri("pack://application:,,,/Resources/HP2.png"),
           new Uri("pack://application:,,,/Resources/HP3.png"));
        private List<Score> _scores;
        private ImageSource _background = new BitmapImage(
            new Uri("pack://application:,,,/Resources/Background.png"));

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<EventArgs> Close;

        public EggAnimator animator { get; } = new EggAnimator();
        public int ScoreCount { get; private set; }
        #endregion

        #region Commands

        public ICommand LTCommand
        {
            get
            {
                return _ltCommand
                 ?? (_ltCommand = new ActionCommand(() =>
                 {
                     CurrentWolf = _wolfLT;
                 }));
            }
        }

        public ICommand LBCommand
        {
            get
            {
                return _lbCommand
                 ?? (_lbCommand = new ActionCommand(() =>
                 {

                     CurrentWolf = _wolfLB;
                 }));
            }
        }

        public ICommand RTCommand
        {
            get
            {
                return _rtCommand
                 ?? (_rtCommand = new ActionCommand(() =>
                 {

                     CurrentWolf = _wolfRT;
                 }));
            }
        }

        public ICommand RBCommand
        {
            get
            {
                return _rbCommand
                 ?? (_rbCommand = new ActionCommand(() =>
                 {

                     CurrentWolf = _wolfRB;
                 }));
            }
        }

        public ICommand WindowsClosing
        {
            get
            {
                return _windowsClosing
                 ?? (_windowsClosing = new ActionCommand(() =>
                 {
                     animator.EndGame();
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
                     animator.StartGame();
                     Game singleOrDefault = (Game)App.Current.Windows.OfType
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

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand
                 ?? (_closeCommand = new ActionCommand(() =>
                 {
                     Game singleOrDefault = (Game)App.Current.Windows.OfType
                      <System.Windows.Window>().SingleOrDefault(x => x.IsActive);
                     singleOrDefault.Close();


                 }));
            }
        }

        #endregion

        #region Changed Property

        public HP Hp
        {
            get { return _hp; }
            set
            {
                _hp = value;
                OnPropertyChanged("Hp");
            }
        }
        public int CurrentScore
        {

            get { return ScoreCount; }
            set
            {
                ScoreCount = value;
                OnPropertyChanged("CurrentScore");
            }
        }

        public ImageSource Background
        {
            get { return _background; }
            set
            {
                _background = value;
                OnPropertyChanged("Background");
            }
        }

        public Wolf CurrentWolf
        {
            get { return _currWolf; }
            set
            {
                _currWolf = value;
                OnPropertyChanged("CurrentWolf");
            }
        }

        public Key LTKey
        {
            get
            {
                return (Key)Enum.Parse(typeof(Key), _config.WolfLTKey);
            }
            set
            {
                _config.WolfLTKey = value.ToString();
                OnPropertyChanged("LTKey");
            }
        }

        public Key LBKey
        {
            get
            {
                return (Key)Enum.Parse(typeof(Key), _config.WolfLBKey);
            }
            set
            {
                _config.WolfLBKey = value.ToString();
                OnPropertyChanged("LBKey");
            }
        }

        public Key RTKey
        {
            get
            {
                return (Key)Enum.Parse(typeof(Key), _config.WolfRTKey);
            }
            set
            {
                _config.WolfRTKey = value.ToString();
                OnPropertyChanged("RTKey");
            }
        }

        public Key RBKey
        {
            get
            {
                return (Key)Enum.Parse(typeof(Key), _config.WolfRBKey);
            }
            set
            {
                _config.WolfRBKey = value.ToString();
                OnPropertyChanged("RBKey");
            }
        }
        #endregion

        private void LifeActive(object sender, EventArgs e)
        {
            switch (animator.BrokenEggs)
            {
                case 1:
                    Hp.Hp1Visibility = Visibility.Visible;
                    break;
                case 2:
                    Hp.Hp2Visibility = Visibility.Visible;
                    break;
                case 3:
                    Hp.Hp3Visibility = Visibility.Visible;
                    animator.EndGame();
                    ScoreCalculation();
                    GameOverWindowShow();
                    Close?.Invoke(this, new EventArgs());
                    break;
                default:
                    break;
            }
        }

        private void GameOverWindowShow() 
        {
            GameOver gameOver = new GameOver(ScoreCount);
            gameOver.ShowDialog();
        }

        private void ScoreCalculation()
        {
            if (CurrentScore > _scores.Min().LeaderScore)
            {
                _scores.Remove(_scores.Min());

                NewHightScore NHS = new NewHightScore();
                NewHightScoreViewModel NHSVM = NHS.DataContext as NewHightScoreViewModel;
                NHSVM.LeaderNameChanged += LeaderNameChanged;
                NHS.ShowDialog();
                _scores.Add(new Score(CurrentScore, _leaderName));
                MySerializer.SerializeXml<List<Score>>(_scores, "LeaderBord.ldr");
            }

        }

        private void LeaderNameChanged(object sender, LeaderNameEventArgs e)
        {
            _leaderName = e.LeaderName;
        }

        public void EggReadyToCatch(object sender, EventArgs e)
        {
            Egg eg = sender as Egg;

            if (_currWolf.Position == eg.SpawnPos)
            {
                CurrentScore++;
                animator.EggRemove(eg, e);
                eg.timer.Stop();
                return;
            }

            else
            {
                animator.EggBroken(eg);
            }
        }

        public GameViewModel(Config cfg)
        {
            _currWolf = _wolfLT;
            animator.ReadyToCatch += EggReadyToCatch;
            animator.LifeActivate += LifeActive;

            _config = cfg;

            if (File.Exists("LeaderBord.ldr"))
            {
                try
                {
                    _scores = MySerializer.DeserializeXml<List<Score>>("LeaderBord.ldr");
                }
                catch (InvalidOperationException) 
                {
                    _scores = Score.GetDeffaultScoreList();
                    CustomMessageBox messageBox = new CustomMessageBox("File LeaderBord.ldr is damaged. Reset to default leader bord");
                    messageBox.ShowDialog();
                    MySerializer.SerializeXml<List<Score>>(_scores, "LeaderBord.ldr");
                }
            }
            else 
            {
                _scores = Score.GetDeffaultScoreList();

            }
            
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
