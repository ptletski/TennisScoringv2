using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoringRules
{
    public interface IGameScorer
    {
        void StartGame();
        void PointWonByServer();
        void PointWonByReceiver();

        GameScore GameScore { get; }
        bool IsGameOver { get; }
        bool IsServerGameWinner { get; }
        bool IsReceiverGameWinner { get; }
    }
}
