using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;

using Electronika.Enums;

namespace Electronika.Models
{
    public class Egg
    {
        private int _currentFrame = 0;
        private const int FallFrameIndex = 5;
        private const int EndOfWayIndex = 10;

        public event EventHandler<EventArgs> TimerStop;
        public event EventHandler<EventArgs> AnimationEnd;
        public event EventHandler<EventArgs> ReadyToCatch;

        public List<Image> EggWay { get; } = new List<Image>();
        public DispatcherTimer timer = new DispatcherTimer();

        public Position SpawnPos { get; private set; }

        public Egg(int spawn)
        {
            SpawnPos = (Position)Enum.Parse(typeof(Position), spawn.ToString());
            EggInit();
            timer.Tick += EggMove;
        }

        public void EggsDeactivate()
        {
            for (int i = 0; i < EggWay.Count; i++)
            {
                EggWay[i].Visibility = Visibility.Hidden;
            }
        }

        public void EggMove(object sender, EventArgs e)
        {
            if (_currentFrame == FallFrameIndex)
            {

                ReadyToCatch?.Invoke(this, new EventArgs());

            }

            if (_currentFrame == EndOfWayIndex)
            {
                TimerStop?.Invoke(this, new EventArgs());
                timer.Stop();
                AnimationEnd?.Invoke(this, new EventArgs());
                return;
            }

            EggsDeactivate();

            EggWay[_currentFrame].Visibility = Visibility.Visible;
            _currentFrame++;
        }

        private void LeftBrokenAdd()
        {
            EggWay.Add(new Image());
            EggWay[FallFrameIndex].Source = new BitmapImage(
                new Uri("pack://application:,,,/Resources/ChickenLeft/BrokenEggLeft.png"));
            EggWay[FallFrameIndex].Stretch = Stretch.Fill;
            EggWay[FallFrameIndex].Visibility = Visibility.Hidden;

            for (int i = FallFrameIndex + 1; i < EndOfWayIndex; i++)
            {
                EggWay.Add(new Image());
                EggWay[i].Source = new BitmapImage(
                    new Uri($"pack://application:,,,/Resources/ChickenLeft/ChickenLeftPos{i - FallFrameIndex}.png"));

                EggWay[i].Stretch = Stretch.Fill;
                EggWay[i].Visibility = Visibility.Hidden;
            }
        }

        private void RightBrokenAdd()
        {
            EggWay.Add(new Image());

            EggWay[FallFrameIndex].Source = new BitmapImage(
                new Uri("pack://application:,,,/Resources/ChickenRight/BrokenEggRight.png"));
            EggWay[FallFrameIndex].Stretch = Stretch.Fill;
            EggWay[FallFrameIndex].Visibility = Visibility.Hidden;

            for (int i = FallFrameIndex + 1; i < EndOfWayIndex; i++)
            {
                EggWay.Add(new Image());
                EggWay[i].Source = new BitmapImage(
                    new Uri($"pack://application:,,,/Resources/ChickenRight/ChickenRightPos{i - FallFrameIndex}.png"));

                EggWay[i].Stretch = Stretch.Fill;
                EggWay[i].Visibility = Visibility.Hidden;
            }
        }

        private void EggInit()
        {
            if (SpawnPos == Position.LeftTop)
            {
                EggGenerate("pack://application:,,,/Resources/LTEggSpawn/LeftEggPos", ".png");
              
            }
            else if (SpawnPos == Position.RightTop)
            {
                EggGenerate("pack://application:,,,/Resources/RTEggSpawn/RightEggPos", ".png");
              
            }
            else if (SpawnPos == Position.LeftBottom)
            {
                EggGenerate("pack://application:,,,/Resources/LBEggSpawn/LBEggPos", ".png");
            }
            else if (SpawnPos == Position.RightBottom)
            {
                EggGenerate("pack://application:,,,/Resources/RBEggSpawn/RBEggPos", ".png");
            }
        }

        private void EggGenerate(string location, string expansion)
        {
            for (int i = 0; i < FallFrameIndex; i++)
            {
                EggWay.Add(new Image());
                EggWay[i].Source = new BitmapImage(
                    new Uri(location + (i + 1) + expansion));
                EggWay[i].Stretch = Stretch.Fill;
                EggWay[i].Visibility = Visibility.Hidden;
            }
            if (SpawnPos == Position.LeftTop || SpawnPos == Position.LeftBottom)
            {
                LeftBrokenAdd();
            }
            else
            {
                RightBrokenAdd();
            }
        }

    }
}
