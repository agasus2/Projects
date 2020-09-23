using System;

namespace Electronika.EventArguments
{
    class LeaderNameEventArgs : EventArgs
    {
        public string LeaderName { get; private set; }
        public LeaderNameEventArgs(string leaderName)
        {
            LeaderName = leaderName;
        }
    }
}
