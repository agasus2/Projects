using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class SequencesContainer
    {
        private int _sequenceSize;
        private List<string> _sequencesString;
        private const int MaxDigit = 9;
        private static Random rand = new Random();

        public int AvailableSequencesCount { get { return _sequencesString.Count; } }
        public int CountOfTry { get; private set; } = 1;

        public SequencesContainer(int sequenceSize)
        {
            _sequenceSize = sequenceSize;
            _sequencesString = new List<string>(GetMaxSize(_sequenceSize));

            Fill();
        }

        private int GetMaxSize(int sequenceSize)
        {
            int maxSize = MaxDigit + 1;

            for (int i = 0; i < sequenceSize - 1; i++)
            {
                maxSize *= (MaxDigit + 1);
            }

            return maxSize;
        }

        private void ExcludeWithAllEqualDigits(string current)
        {
            List<string> includedSequences = new List<string>();

            for (int i = 0; i < _sequencesString.Count; i++)
            {
                if (!Contains(_sequencesString[i], current))
                {
                    includedSequences.Add(_sequencesString[i]);
                }
            }

            _sequencesString = includedSequences;
        }

        public void ExcludeByBullsAndCows(string current, int bulls, int cows)
        {
            CountOfTry++;

            List<string> includedSequences = new List<string>();

            if (bulls == 0 && cows == 0)
            {
                ExcludeWithAllEqualDigits(current);
            }
            else
            {
                for (int i = 0; i < _sequencesString.Count; i++)
                {
                    if (BullsOrCowsCountEqual(_sequencesString[i], current, bulls, cows))
                    {

                        includedSequences.Add(_sequencesString[i]);
                    }
                }

                _sequencesString = includedSequences;
            }
        }

        public string GetNextSequence()
        {
            if (_sequencesString.Count != 0)
            {
                return _sequencesString[rand.Next(0, _sequencesString.Count - 1)];
            }

            return null;
        }

        private void Fill()
        {
            string str = new string('0', _sequenceSize);

            for (int i = 0; i < GetMaxSize(_sequenceSize); i++)
            {
                _sequencesString.Add(String.Format("{0:" + str + "}", i));
            }
        }

        private bool BullsOrCowsCountEqual(string currentString, string compString, int bullsCount, int cowsCount)
        {
            int countOfBulls = 0;
            int countOfCows = 0;

            for (int i = 0; i < _sequenceSize; i++)
            {
                if (currentString[i] == compString[i])
                {
                    countOfBulls++;
                }

                if (currentString[i] != compString[i] && currentString.Contains(compString[i]))
                {
                    countOfCows++;
                }
            }

            if (countOfBulls != bullsCount || countOfCows < cowsCount)
            {
                return false;
            }

            return true;
        }

        private bool Contains(string currentComp, string compStr)
        {
            for (int i = 0; i < _sequenceSize; i++)
            {
                if (currentComp.Contains(compStr[i]))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
