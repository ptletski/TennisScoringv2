using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TennisScoringRules
{
    public class GamePlay
    {
        IGameScorer _scorer;
        byte _missedServiceCount;

        public GamePlay(IGameScorer scorer)
        {
            _scorer = scorer;
        }

        public void BeginGame()
        {
            _scorer.StartGame();
            ResetServiceCount();
        }

        public GameScore GameScore
        {
            get
            {
                return _scorer.GameScore;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return _scorer.IsGameOver;
            }
        }

        public bool IsServerGameWinner
        {
            get
            {
                return _scorer.IsServerGameWinner;
            }
        }

        public bool IsReceiverGameWinner
        {
            get
            {
                return _scorer.IsReceiverGameWinner;
            }
        }

        public bool FaultByServer(ref string outcome)
        {
            bool isDoubleFault = false;
            string result = String.Empty;

            if (_missedServiceCount == 0)
            {
                _missedServiceCount++;
                result = "Second Service";
            }
            else if (_missedServiceCount == 1)
            {
                isDoubleFault = true;
                result = "Double Fault";
                DoubleFaultByServer();
            }
            else
            {
                Debug.Assert(false, "Bad missed service count");
            }

            outcome = result;
            return isDoubleFault;
        }

        public string LetByServer()
        {
            string result = String.Empty;

            if (_missedServiceCount == 0)
            {
                result = "First Service";
            }
            else if (_missedServiceCount == 1)
            {
                result = "Second Service";
            }
            else
            {
                Debug.Assert(false, "Bad missed service count");
            }

            return result;
        }

        public void WinnerByServer()
        {
            _scorer.PointWonByServer();
        }

        public void WinnerByReceiver()
        {
            _scorer.PointWonByReceiver();
        }

        public void UnforcedErrorByServer()
        {
            _scorer.PointWonByReceiver();
        }

        public void UnforcedErrorByReceiver()
        {
            _scorer.PointWonByServer();
        }

        public void PenaltyByServer()
        {
            _scorer.PointWonByReceiver();
        }

        public void PenaltyByReceiver()
        {
            _scorer.PointWonByServer();
        }

        private void ResetServiceCount()
        {
            _missedServiceCount = 0;
        }

        private void DoubleFaultByServer()
        {
            _scorer.PointWonByReceiver();
            ResetServiceCount();
        }
    }
}
