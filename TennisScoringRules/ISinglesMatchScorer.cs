using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoringRules
{
    public interface ISinglesMatchScorer
    {
        void BeginMatch();
        bool IsMatchOver { get; }

        void BeginSet();
        bool IsSetOver { get; }

        bool IsMatchWinnerPlayer1 { get; }
        bool IsMatchWinnerPlayer2 { get; }

        void GameWonByPlayer1();
        void GameWonByPlayer2();

        SetScore ScoreOfSet { get; }
        MatchScore ScoreOfMatch { get; }
    }
}
