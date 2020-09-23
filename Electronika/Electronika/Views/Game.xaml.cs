using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

using Electronika.Models;
using Electronika.ViewModels;

namespace Electronika.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Game : Window
    {
        private Config _cfg;
        private GameViewModel _gameViewModel; 
        private DispatcherTimer _timer = new DispatcherTimer();

        public Game(Config cfg)
        {
            _cfg = cfg;
            InitializeComponent();
            _gameViewModel = new GameViewModel(_cfg);
            _gameViewModel.animator.InitEgg += Init;
            _gameViewModel.animator.DeleteEgg += EggRemove;
            _gameViewModel.animator.TimerStop += Stop_timer;
            _gameViewModel.animator.TimerStart += Start_timer;
            _gameViewModel.Close += WindowClose;
            DataContext = _gameViewModel;
            _timer.Tick += _gameViewModel.animator.InitEggs;
        }

        public void WindowClose(object sender, EventArgs e) 
        {
            this.Close();
        }

        public void Stop_timer(object sender, EventArgs e) 
        {
            _timer.Stop();
        }

        public void Start_timer(object sender, EventArgs e)
        {
            _timerStart(_cfg.GameSpeed);
        }

        private void Init(object sender , EventArgs e)
        {
            Egg eg = sender as Egg;

            foreach (Image im in eg.EggWay)
            {
                MainGrid.Children.Add(im);
            }

            if (_gameViewModel.ScoreCount % 10 == 0)
            {
                _timer.Stop();
                _cfg.GameSpeed = GameSpeedRestriction(_cfg.GameSpeed);
                _timerStart(_cfg.GameSpeed);
            }
        }
 
        private void EggRemove(object sender, EventArgs e)
        {
            Egg eg = sender as Egg;

            foreach (Image im in eg.EggWay)
            {
                MainGrid.Children.Remove(im);
            }
        }

        private double GameSpeedRestriction(double gameSpeed)
        {
            if (gameSpeed <= 1.0)
            {
                return 1.0;
            }
            else
            {
                return gameSpeed - 0.1;
            }
        }
         
        private void _timerStart(double interval)
        {
            _timer.Interval = TimeSpan.FromSeconds(interval);
            _timer.Start();
        }

    }
}
