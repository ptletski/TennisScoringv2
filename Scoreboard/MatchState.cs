using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scoreboard
{
    public class MatchState
    {
        bool _isGameOver;
        bool _isSetOver;
        bool _isMatchOver;

        byte _setsWonByPlayer1;
        byte _setsWonByPlayer2;

        byte _gamesWonByPlayer1;
        byte _gamesWonByPlayer2;

        ServingPlayer _playerServing;

        string _scorePlayer1;
        string _scorePlayer2;
        string _adScore;
        string _message;

        public MatchState(bool isGameOver,
                        bool isSetOver,
                        bool isMatchOver,
                        byte setsWonByPlayer1,
                        byte setsWonByPlayer2,
                        byte gamesWonByPlayer1,
                        byte gamesWonByPlayer2,
                        ServingPlayer playerServing,
                        string scorePlayer1,
                        string scorePlayer2,
                        string advantageScore,
                        string message)
        {
            _isGameOver = isGameOver;
            _isSetOver = isSetOver;
            _isMatchOver = isMatchOver;

            _setsWonByPlayer1 = setsWonByPlayer1;
            _setsWonByPlayer2 = setsWonByPlayer2;

            _gamesWonByPlayer1 = gamesWonByPlayer1;
            _gamesWonByPlayer2 = gamesWonByPlayer2;

            _playerServing = playerServing;

            _scorePlayer1 = scorePlayer1;
            _scorePlayer2 = scorePlayer2;
            _adScore = advantageScore;

            _message = message;
        }

        public byte SetsWonByPlayer1
        {
            get
            {
                return _setsWonByPlayer1;
            }
        }

        public byte SetsWonByPlayer2
        {
            get
            {
                return _setsWonByPlayer2;
            }
        }

        public byte GamesWonByPlayer1
        {
            get
            {
                return _gamesWonByPlayer1;
            }
        }

        public byte GamesWonByPlayer2
        {
            get
            {
                return _gamesWonByPlayer2;
            }
        }
        
        public bool IsGameOver
        {
            get
            {
                return _isGameOver;
            }
        }

        public bool IsSetOver
        {
            get
            {
                return _isSetOver;
            }
        }

        public bool IsMatchOver
        {
            get
            {
                return _isMatchOver;
            }
        }

        public ServingPlayer ServingPlayer
        {
            get
            {
                return _playerServing;
            }
        }

        public string ScorePlayer1
        {
            get
            {
                return _scorePlayer1;
            }
        }

        public string ScorePlayer2
        {
            get
            {
                return _scorePlayer2;
            }
        }

        public string AdvantageScore
        {
            get
            {
                return _adScore;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
