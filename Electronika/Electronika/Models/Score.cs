using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Electronika.Models
{   
   [Serializable]
   public class Score : INotifyPropertyChanged, IComparable<Score>
    {
        private string _leaderName;
        private int _leaderScore;

        public event PropertyChangedEventHandler PropertyChanged;

        public string LeaderName 
        {
            get 
            {
                return _leaderName; 
            }
            set 
            {
                _leaderName = value;
                OnPropertyChanged("LeaderName");
            }
        }

        public int LeaderScore
        {
            get
            {
                return _leaderScore;
            }
            set
            {
                _leaderScore = value;
                OnPropertyChanged("LeaderScore");
            }
        }

        public int CompareTo(Score score)
        {
           
                return this.LeaderScore.CompareTo(score.LeaderScore);
      
        }
        public Score()
        {

        }

        public Score(int score, string leaderName)
        {
            LeaderScore = score;
            LeaderName = leaderName;
        }
        public static List<Score> GetDeffaultScoreList() 
        {
            return new List<Score>
            {   new Score {LeaderName="Jack", LeaderScore = 100},
                new Score {LeaderName="Ron", LeaderScore = 500},
                new Score {LeaderName="Sam", LeaderScore = 400 },
                new Score {LeaderName="Sara", LeaderScore = 300},
                new Score {LeaderName="Jenifer", LeaderScore = 200},
                new Score {LeaderName="Niki", LeaderScore = 50},
                new Score {LeaderName="Harry", LeaderScore = 50}

            };
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
