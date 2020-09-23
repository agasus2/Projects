using System;
using System.Collections.Generic;

namespace Electronika.Models
{
    public class EggAnimator
    {
        private List<Egg> _countOfEggs = new List<Egg>();
        private Random _r = new Random();
        private const int MaxSpawnIndex = 4;
        private const double FrameChangeInterval = 0.5;

        public event EventHandler<EventArgs> InitEgg;
        public event EventHandler<EventArgs> DeleteEgg;
        public event EventHandler<EventArgs> TimerStop;
        public event EventHandler<EventArgs> TimerStart;
        public event EventHandler<EventArgs> LifeActivate;
        public event EventHandler<EventArgs> ReadyToCatch;
        public int BrokenEggs { get; private set; } = 0;
       
        #region EggAnimation

        private void AnimationEnd(object sender, EventArgs e)
        {
            DeleteEgg?.Invoke(sender, e);
            TimerStart?.Invoke(this, e);
        }

        public void EggRemove(object sender, EventArgs e)
        {
            Egg eg = sender as Egg;
            _countOfEggs.Remove(eg);
            DeleteEgg?.Invoke(eg, e);

        }

        public void StartGame()
        {
            TimerStart?.Invoke(this, new EventArgs());
        }
        public void EndGame()
        {
            TimerStop?.Invoke(this, new EventArgs());
            RemoveAllEggs();
        }
        public void InitEggs(object sender, EventArgs e)
        {
            Egg eg = new Egg(_r.Next(1, MaxSpawnIndex + 1));
            _countOfEggs.Add(eg);
            eg.TimerStop += EggRemove;
            eg.ReadyToCatch += ReadyToCatch;
            eg.AnimationEnd += AnimationEnd;
            InitEgg?.Invoke(eg, new EventArgs());

            eg.timer.Interval = TimeSpan.FromSeconds(FrameChangeInterval);
            eg.timer.Start();
        }

        public void EggBroken(Egg brokenEgg)
        {
            TimerStop?.Invoke(this, new EventArgs());
            BrokenEggs++;

            foreach (Egg eg in _countOfEggs)
            {
                if (eg != brokenEgg)
                {
                    eg.timer.Stop();
                    DeleteEgg?.Invoke(eg, new EventArgs());
                }
            }

            LifeActivate?.Invoke(this, new EventArgs());
        }

        private void RemoveAllEggs()
        {
            foreach (Egg eg in _countOfEggs)
            {

                eg.timer.Stop();

                DeleteEgg?.Invoke(eg, new EventArgs());

            }

            _countOfEggs.Clear();
        }



        #endregion
    }
}
