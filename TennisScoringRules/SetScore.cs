using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoringRules
{
    public class SetScore
    {
        byte _gamesWonPlayer1;
        byte _gamesWonPlayer2;

        public SetScore(byte gamesPlayer1, byte gamesPlayer2)
        {
            _gamesWonPlayer1 = gamesPlayer1;
            _gamesWonPlayer2 = gamesPlayer2;
        }

        public byte Player1
        {
            get
            {
                return _gamesWonPlayer1;
            }

            set
            {
                _gamesWonPlayer1 = value;
            }
        }

        public byte Player2
        {
            get
            {
                return _gamesWonPlayer2;
            }

            set
            {
                _gamesWonPlayer2 = value;
            }
        }

        public override string ToString()
        {
            string result = String.Empty;
            result = String.Format("{0}-{1}", _gamesWonPlayer1, _gamesWonPlayer2);
            return result;
        }
    }
}
