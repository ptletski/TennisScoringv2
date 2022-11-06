using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TennisScoringRules
{
    public class GameScorer : IGameScorer
    {
        int _scoreServer;
        int _scoreReceiver;

        public GameScorer()
        {
        }

        public void StartGame()
        {
            _scoreServer = 0;
            _scoreReceiver = 0;
        }

        public void PointWonByServer()
        {
            _scoreServer++;
        }

        public void PointWonByReceiver()
        {
            _scoreReceiver++;
        }

        public GameScore GameScore
        {
            get
            {
                string adScore = String.Empty;
                string serverScore = "40";
                string receiverScore = "40";

                if ((_scoreServer >= 3) && (_scoreReceiver >= 3))
                {
                    adScore = ConvertScoreToAdScoring();
                }
                else
                {
                    serverScore = ConvertIndexScoreToTraditionalScore(_scoreServer);
                    receiverScore = ConvertIndexScoreToTraditionalScore(_scoreReceiver);
                }

                return new GameScore(serverScore, receiverScore, adScore);
            }
        }

        public bool IsGameOver
        {
            get
            {
                bool isGameOver = false;

                if ((_scoreServer > 3) || (_scoreReceiver > 3))
                {
                    int difference = Math.Abs(_scoreServer - _scoreReceiver);

                    if (difference >= 2)
                    {
                        isGameOver = true;
                    }
                }

                return isGameOver;
            }
        }

        public bool IsServerGameWinner
        {
            get
            {
                Debug.Assert(IsGameOver, "Game isn't over yet");

                bool isWinner = false;

                if (_scoreServer > _scoreReceiver)
                {
                    isWinner = true;
                }

                return isWinner;
            }
        }

        public bool IsReceiverGameWinner
        {
            get
            {
                Debug.Assert(IsGameOver, "Game isn't over yet");

                bool isWinner = false;

                if (_scoreServer < _scoreReceiver)
                {
                    isWinner = true;
                }

                return isWinner;
            }
        }

        private string ConvertIndexScoreToTraditionalScore(int indexScore)
        {
            string result = String.Empty;

            switch (indexScore)
            {
                case 0: 
                    result = "0";
                    break;
                case 1:
                    result = "15";
                    break;
                case 2:
                    result = "30";
                    break;
                case 3:
                    result = "40";
                    break;
                default:
                    result = String.Empty;
                    break;
            }

            return result;
        }

        private string ConvertScoreToAdScoring()
        {
            Debug.Assert((_scoreServer >= 3) && (_scoreReceiver >= 3), "Calling inappropariatel");

            string result = String.Empty;

            if (_scoreServer == _scoreReceiver)
            {
                result = "DEUCE";
            }
            else if (_scoreServer > _scoreReceiver)
            {
                result = "AD IN";
            }
            else
            {
                result = "AD OUT";
            }

            return result;
        }
    }
}
