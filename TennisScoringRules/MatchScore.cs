using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoringRules
{
    public class MatchScore
    {
        byte _setsWonPlayer1;
        byte _setsWonPlayer2;

        public MatchScore(byte setsPlayer1, byte setsPlayer2)
        {
            _setsWonPlayer1 = setsPlayer1;
            _setsWonPlayer2 = setsPlayer2;
        }

        public byte Player1
        {
            get
            {
                return _setsWonPlayer1;
            }

            set
            {
                _setsWonPlayer1 = value;
            }
        }

        public byte Player2
        {
            get
            {
                return _setsWonPlayer2;
            }

            set
            {
                _setsWonPlayer2 = value;
            }
        }

        public override string ToString()
        {
            string result = String.Empty;
            result = String.Format("{0}-{1}", _setsWonPlayer1, _setsWonPlayer2);
            return result;
        }
    }
}
