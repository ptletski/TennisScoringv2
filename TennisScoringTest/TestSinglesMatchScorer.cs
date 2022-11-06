using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisScoringRules;
using System.Diagnostics;

namespace TennisScoringTest
{
    class TestSinglesMatchScorer
    {
        public static void ExecuteTestSuite()
        {
            TestBeginMatchTwoOfThree();
            TestEndofSetPlayer1();
            TestEndofSetPlayer2();
            TestEndofMatch2of3Player1();
            TestEndofMatch2of3Player2();
            TestEndofMatch3of5Player1();
            TestEndofMatch3of5Player2();
        }

        public static void TestBeginMatchTwoOfThree()
        {
            SinglesMatchScorer scorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);

            scorer.BeginMatch();
            bool isMatchOver = scorer.IsMatchOver;

            Debug.Assert(!isMatchOver, "Match should not be over");
        }

        public static void TestEndofSetPlayer1()
        {
            SinglesMatchScorer scorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);

            scorer.BeginMatch();

            bool isSetOver = scorer.IsSetOver;
            Debug.Assert(!isSetOver, "Set should not be over");

            scorer.GameWonByPlayer1();
            scorer.GameWonByPlayer1();
            scorer.GameWonByPlayer1();
            scorer.GameWonByPlayer1();
            scorer.GameWonByPlayer1();
            scorer.GameWonByPlayer1();

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            bool isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");
        }

        public static void TestEndofSetPlayer2()
        {
            SinglesMatchScorer scorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);

            scorer.BeginMatch();

            bool isSetOver = scorer.IsSetOver;
            Debug.Assert(!isSetOver, "Set should not be over");

            scorer.GameWonByPlayer2();
            scorer.GameWonByPlayer2();
            scorer.GameWonByPlayer2();
            scorer.GameWonByPlayer2();
            scorer.GameWonByPlayer2();
            scorer.GameWonByPlayer2();

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            bool isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");
        }

        public static void TestEndofMatch2of3Player1()
        {
            SinglesMatchScorer scorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);

            scorer.BeginMatch();

            bool isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            string matchScore = scorer.ScoreOfMatch.ToString();
            bool isMatchScoreRight = String.Equals(matchScore, "0-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            bool isSetOver = scorer.IsSetOver;
            Debug.Assert(!isSetOver, "Set should not be over");
            string setScore = scorer.ScoreOfSet.ToString();
            bool isSetScoreRight = String.Equals(setScore, "0-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "1-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "2-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "3-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "4-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "5-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "6-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "1-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "1-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "2-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "3-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "4-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "5-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "6-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(isMatchOver, "Match should be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "2-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            bool isMatchWinnerPlayer1 = scorer.IsMatchWinnerPlayer1;
            Debug.Assert(isMatchWinnerPlayer1, "Wrong winner");

            bool isMatchWinnerPlayer2 = scorer.IsMatchWinnerPlayer2;
            Debug.Assert(!isMatchWinnerPlayer2, "Wrong winner");
        }

        public static void TestEndofMatch2of3Player2()
        {
            SinglesMatchScorer scorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);

            scorer.BeginMatch();

            bool isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            string matchScore = scorer.ScoreOfMatch.ToString();
            bool isMatchScoreRight = String.Equals(matchScore, "0-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            bool isSetOver = scorer.IsSetOver;
            Debug.Assert(!isSetOver, "Set should not be over");
            string setScore = scorer.ScoreOfSet.ToString();
            bool isSetScoreRight = String.Equals(setScore, "0-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-1");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-2");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-3");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-4");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-5");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-6");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "0-1");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-1");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-2");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-3");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-4");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-5");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-6");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(isMatchOver, "Match should be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "0-2");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            bool isMatchWinnerPlayer1 = scorer.IsMatchWinnerPlayer1;
            Debug.Assert(!isMatchWinnerPlayer1, "Wrong winner");

            bool isMatchWinnerPlayer2 = scorer.IsMatchWinnerPlayer2;
            Debug.Assert(isMatchWinnerPlayer2, "Wrong winner");
        }

        public static void TestEndofMatch3of5Player1()
        {
            SinglesMatchScorer scorer = new SinglesMatchScorer(MatchSeries.ThreeOfFive);

            scorer.BeginMatch();

            bool isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            string matchScore = scorer.ScoreOfMatch.ToString();
            bool isMatchScoreRight = String.Equals(matchScore, "0-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            bool isSetOver = scorer.IsSetOver;
            Debug.Assert(!isSetOver, "Set should not be over");
            string setScore = scorer.ScoreOfSet.ToString();
            bool isSetScoreRight = String.Equals(setScore, "0-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "1-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "2-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "3-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "4-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "5-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "6-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "1-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            isSetOver = scorer.IsSetOver;
            Debug.Assert(!isSetOver, "Set should not be over");
            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "1-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "2-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "3-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "4-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "5-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "6-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "2-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "1-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "2-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "3-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "4-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "5-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer1();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "6-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(isMatchOver, "Match should be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "3-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            bool isMatchWinnerPlayer1 = scorer.IsMatchWinnerPlayer1;
            Debug.Assert(isMatchWinnerPlayer1, "Wrong winner");

            bool isMatchWinnerPlayer2 = scorer.IsMatchWinnerPlayer2;
            Debug.Assert(!isMatchWinnerPlayer2, "Wrong winner");
        }

        public static void TestEndofMatch3of5Player2()
        {
            SinglesMatchScorer scorer = new SinglesMatchScorer(MatchSeries.ThreeOfFive);

            scorer.BeginMatch();

            bool isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            string matchScore = scorer.ScoreOfMatch.ToString();
            bool isMatchScoreRight = String.Equals(matchScore, "0-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            bool isSetOver = scorer.IsSetOver;
            Debug.Assert(!isSetOver, "Set should not be over");
            string setScore = scorer.ScoreOfSet.ToString();
            bool isSetScoreRight = String.Equals(setScore, "0-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-1");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-2");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-3");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-4");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-5");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-6");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "0-1");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            isSetOver = scorer.IsSetOver;
            Debug.Assert(!isSetOver, "Set should not be over");
            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-1");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-2");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-3");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-4");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-5");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-6");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "0-2");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            scorer.BeginSet();

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-1");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-2");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-3");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-4");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-5");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            scorer.GameWonByPlayer2();

            setScore = scorer.ScoreOfSet.ToString();
            isSetScoreRight = String.Equals(setScore, "0-6");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            isSetOver = scorer.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");

            isMatchOver = scorer.IsMatchOver;
            Debug.Assert(isMatchOver, "Match should be over");

            matchScore = scorer.ScoreOfMatch.ToString();
            isMatchScoreRight = String.Equals(matchScore, "0-3");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");

            bool isMatchWinnerPlayer1 = scorer.IsMatchWinnerPlayer1;
            Debug.Assert(!isMatchWinnerPlayer1, "Wrong winner");

            bool isMatchWinnerPlayer2 = scorer.IsMatchWinnerPlayer2;
            Debug.Assert(isMatchWinnerPlayer2, "Wrong winner");
        }
    }
}
