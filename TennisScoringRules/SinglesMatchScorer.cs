using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TennisScoringRules
{
    public enum MatchSeries { TwoOfThree, ThreeOfFive };

    public class SinglesMatchScorer : ISinglesMatchScorer
    {
        byte _gamesWonByPlayer1;
        byte _gamesWonByPlayer2;
        byte _setsWonByPlayer1;
        byte _setsWonByPlayer2;
        bool _isMatchWinnerPlayer1;
        bool _isMatchWinnerPlayer2;

        MatchSeries _setCount;

        public SinglesMatchScorer(MatchSeries setCount)
        {
            _setCount = setCount;
        }

        public void BeginMatch()
        {
            _setsWonByPlayer1 = 0;
            _setsWonByPlayer2 = 0;

            _isMatchWinnerPlayer1 = false;
            _isMatchWinnerPlayer1 = false;
        }
        
        public bool IsMatchOver
        {
            get
            {
                bool isMatchOver = false;

                if (_setCount == MatchSeries.TwoOfThree)
                {
                    isMatchOver = DecideIfMatchIsOver(2);
                }
                else if (_setCount == MatchSeries.ThreeOfFive)
                {
                    isMatchOver = DecideIfMatchIsOver(3);
                }

                return isMatchOver;
            }
        }

        public void BeginSet()
        {
            _gamesWonByPlayer1 = 0;
            _gamesWonByPlayer2 = 0;
        }

        public bool IsSetOver
        {
            get
            {
                bool isSetOver = false;

                if ((_gamesWonByPlayer1 >= 6) || (_gamesWonByPlayer2 >= 6))
                {
                    int difference = Math.Abs(_gamesWonByPlayer1 - _gamesWonByPlayer2);

                    if (difference >= 2)
                    {
                        isSetOver = true;
                    }
                }

                return isSetOver;
            }
        }

        public bool IsMatchWinnerPlayer1
        {
            get
            {
                return _isMatchWinnerPlayer1;
            }
        }

        public bool IsMatchWinnerPlayer2
        {
            get
            {
                return _isMatchWinnerPlayer2;
            }
        }

        public void GameWonByPlayer1()
        {
            _gamesWonByPlayer1++;

            if (IsSetOver == true)
            {
                _setsWonByPlayer1++;
            }
        }

        public void GameWonByPlayer2()
        {
            _gamesWonByPlayer2++;

            if (IsSetOver == true)
            {
                _setsWonByPlayer2++;
            }
        }

        public SetScore ScoreOfSet
        {
            get
            {
                SetScore setScore = new SetScore(_gamesWonByPlayer1, _gamesWonByPlayer2);
                return setScore;
            }
        }

        public MatchScore ScoreOfMatch
        {
            get
            {
                MatchScore matchScore = new MatchScore(_setsWonByPlayer1, _setsWonByPlayer2);
                return matchScore;
            }
        }

        private bool DecideIfMatchIsOver(int neededNumberOfSets)
        {
            bool isMatchOver = false;

            if ((_setsWonByPlayer1 == neededNumberOfSets) || (_setsWonByPlayer1 == neededNumberOfSets))
            {
                isMatchOver = true;
                _isMatchWinnerPlayer1 = true;
            }
            else if ((_setsWonByPlayer2 == neededNumberOfSets) || (_setsWonByPlayer2 == neededNumberOfSets))
            {
                isMatchOver = true;
                _isMatchWinnerPlayer2 = true;
            }

            return isMatchOver;
        }
    }
}
