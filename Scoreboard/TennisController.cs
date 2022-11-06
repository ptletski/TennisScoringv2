using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisScoringRules;

namespace Scoreboard
{
    public enum MatchGameSeries { Best2of3, Best3of5 };

    public class TennisController
    {
        Player _player1;
        Player _player2;
        GameScorer _gameScorer;
        GamePlay _gamePlay;
        SinglesMatchScorer _matchScorer;
        SinglesMatchPlay _matchPlay;
        MatchSeries _matchDuration;
        ServerReceiver _serverReceiver;

        public TennisController()
        {
        }

        public ServingPlayer BeginMatch(PlayerName player1, PlayerName player2, MatchGameSeries series)
        {
            _player1 = new Player(player1.FirstName, player1.LastName, "USTA", "OHIO", "2.5 Men Over 50");
            _player2 = new Player(player1.FirstName, player2.LastName, "USTA", "OHIO", "4.5 Women Over 50");

            _gameScorer = new GameScorer();
            _gamePlay = new GamePlay(_gameScorer);

            _matchDuration = (series == MatchGameSeries.Best2of3) ?
                MatchSeries.TwoOfThree :
                MatchSeries.ThreeOfFive;

            _matchScorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);
            _matchPlay = new SinglesMatchPlay(_player1, _player2, _matchScorer);

            _serverReceiver = _matchPlay.BeginMatch();

            return DetermineServicePlayer(_serverReceiver);
        }

        public void BeginSet()
        {
            _matchPlay.BeginSet();
        }

        public void BeginGame()
        {
            _gamePlay.BeginGame();
        }

        public MatchState FaultByServer()
        {
            string message = String.Empty;

            _gamePlay.FaultByServer(ref message);

            return DetermineMatchState(message);
        }

        public MatchState LetByServer()
        {
            string message = _gamePlay.LetByServer();
            return DetermineMatchState(message);
        }

        public MatchState WinnerByServer()
        {
            _gamePlay.WinnerByServer();
            return DetermineMatchState(String.Empty);
        }

        public MatchState WinnerByReceiver()
        {
            _gamePlay.WinnerByReceiver();
            return DetermineMatchState(String.Empty);
        }

        public MatchState UnforcedErrorByServer()
        {
            _gamePlay.UnforcedErrorByServer();
            return DetermineMatchState(String.Empty);
        }

        public MatchState UnforcedErrorByReceiver()
        {
            _gamePlay.UnforcedErrorByReceiver();
            return DetermineMatchState(String.Empty);
        }

        public MatchState PenalizeServer()
        {
            _gamePlay.PenaltyByServer();
            return DetermineMatchState(String.Empty);
        }

        public MatchState PenalizeReceiver()
        {
            _gamePlay.PenaltyByReceiver();
            return DetermineMatchState(String.Empty);
        }

        private ServingPlayer DetermineServicePlayer(ServerReceiver serverReceiver)
        {
            string serverName = serverReceiver.Server.FullName;
            string player1Name = _player1.FullName;
            bool isPlayer1 = String.Equals(serverName, player1Name);

            return (isPlayer1 == true) ? ServingPlayer.Player1 : ServingPlayer.Player2;
        }

        private MatchState DetermineMatchState(string message)
        {
            bool isSetOver = false;
            bool isMatchOver = false;
            bool isGameOver = _gamePlay.IsGameOver;

            if (isGameOver == true)
            {
                CreditGameWinnerForSet();

                isSetOver = _matchPlay.IsSetOver;
                isMatchOver = _matchPlay.IsMatchOver;
            }

            SetScore setScore = _matchScorer.ScoreOfSet;
            MatchScore matchScore = _matchScorer.ScoreOfMatch;
            GameScore gameScore = _gamePlay.GameScore;

            string scorePlayer1 = String.Empty;
            string scorePlayer2 = String.Empty;
            Player server = _serverReceiver.Server;
            Player receiver = _serverReceiver.Receiver;

            if (isGameOver == true)
            {
                if (message != null && message.Length > 0)
                {
                    message += "\n";
                }

                message += "Game Over";
                scorePlayer1 = "0";
                scorePlayer2 = "0";

                _serverReceiver.Flip();
            }
            else
            {
                if (_player1 == server)
                {
                    scorePlayer1 = gameScore.ServerScore;
                    scorePlayer2 = gameScore.ReceiverScore;
                }
                else
                {
                    scorePlayer2 = gameScore.ServerScore;
                    scorePlayer1 = gameScore.ReceiverScore;
                }
            }

            if (isSetOver == true)
            {
                message += "\nSet Over";
            }

            if (isMatchOver == true)
            {
                message = "Match Over";
            }

            string adScore = gameScore.AdScore;

            byte setsWonByPlayer1 = matchScore.Player1;
            byte setsWonByPlayer2 = matchScore.Player2;
            byte gamesWonByPlayer1 = setScore.Player1;
            byte gamesWonByPlayer2 = setScore.Player2;

            ServingPlayer playerServing = DetermineServicePlayer(_serverReceiver);

            MatchState matchState = new MatchState(isGameOver,
                        isSetOver,
                        isMatchOver,
                        setsWonByPlayer1,
                        setsWonByPlayer2,
                        gamesWonByPlayer1,
                        gamesWonByPlayer2,
                        playerServing,
                        scorePlayer1,
                        scorePlayer2,
                        adScore,
                        message);

            return matchState;
        }

        private void CreditGameWinnerForSet()
        {
            if (_gamePlay.IsServerGameWinner == true)
            {
                Player player = _serverReceiver.Server;

                if (player == _player1)
                {
                    _matchScorer.GameWonByPlayer1();
                }
                else
                {
                    _matchScorer.GameWonByPlayer2();
                }
            }
            else
            {
                Player player = _serverReceiver.Receiver;

                if (player == _player1)
                {
                    _matchScorer.GameWonByPlayer1();
                }
                else
                {
                    _matchScorer.GameWonByPlayer2();
                }
            }
        }
    }
}
