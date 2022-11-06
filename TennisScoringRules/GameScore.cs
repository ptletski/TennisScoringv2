using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoringRules
{
    public class GameScore
    {
        string _serverScore;
        string _receiverScore;
        string _adScore;

        public GameScore(string serverScore, string receiverScore, string adScore)
        {
            _serverScore = serverScore;
            _receiverScore = receiverScore;
            _adScore = adScore;
        }

        public string ServerScore
        {
            get
            {
                return _serverScore;
            }
        }

        public string ReceiverScore
        {
            get
            {
                return _receiverScore;
            }
        }

        public string AdScore
        {
            get
            {
                return _adScore;
            }
        }

        public override string ToString()
        {
            string result = String.Empty;

            if (String.IsNullOrEmpty(_adScore))
            {
                result = String.Format("{0}-{1}", _serverScore, _receiverScore);
            }
            else
            {
                result = _adScore;
            }

            return result;
        }
    }
}
