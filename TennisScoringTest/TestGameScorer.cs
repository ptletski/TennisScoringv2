using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisScoringRules;
using System.Diagnostics;

namespace TennisScoringTest
{
    internal class TestGameScorer
    {
        public static void ExecuteTestSuite()
        {
            TestScoreNoPoints();
            TestScoreServerPoint();
            TestScoreReceiverPoint();
            TestScore15_40();
            TestScore30_30();
            TestScoreDeuce();
            TestScoreAdIn();
            TestScoreAdOut();
            TestGameOver();
            TestLongGame();
        }

        static void TestScoreNoPoints()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();
            string score = scorer.GameScore.ToString();

            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
        }

        static void TestScoreServerPoint()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();
            scorer.PointWonByServer();

            string score = scorer.GameScore.ToString();

            bool isScoreOk = String.Equals(score, "15-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
        }

        static void TestScoreReceiverPoint()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();
            scorer.PointWonByReceiver();

            string score = scorer.GameScore.ToString();

            bool isScoreOk = String.Equals(score, "0-15");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
        }

        static void TestScore15_40()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();
            scorer.PointWonByServer();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();

            string score = scorer.GameScore.ToString();

            bool isScoreOk = String.Equals(score, "15-40");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
        }

        static void TestScore30_30()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();
            scorer.PointWonByServer();
            scorer.PointWonByServer();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();

            string score = scorer.GameScore.ToString();

            bool isScoreOk = String.Equals(score, "30-30");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
        }

        static void TestScoreDeuce()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();
            scorer.PointWonByServer();
            scorer.PointWonByServer();
            scorer.PointWonByServer();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();

            string score = scorer.GameScore.ToString();

            bool isScoreOk = String.Equals(score, "DEUCE");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
        }

        static void TestScoreAdIn()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();
            scorer.PointWonByServer();
            scorer.PointWonByServer();
            scorer.PointWonByServer();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();
            scorer.PointWonByServer();

            string score = scorer.GameScore.ToString();

            bool isScoreOk = String.Equals(score, "AD IN");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
        }

        static void TestScoreAdOut()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();
            scorer.PointWonByServer();
            scorer.PointWonByServer();
            scorer.PointWonByServer();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();

            string score = scorer.GameScore.ToString();

            bool isScoreOk = String.Equals(score, "AD OUT");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
        }

        static void TestGameOver()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();
            scorer.PointWonByReceiver();

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(isGameOver, "False game ending");
        }

        static void TestLongGame()
        {
            GameScorer scorer = new GameScorer();

            scorer.StartGame();

            string score = scorer.GameScore.ToString();
            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");
            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            scorer.PointWonByReceiver();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-15");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByServer();
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = scorer.IsGameOver;
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "15-15");
            Debug.Assert(!isGameOver, "False game ending");

            scorer.PointWonByReceiver();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "15-30");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByServer();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "30-30");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByServer();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "40-30");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByReceiver();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "DEUCE");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByReceiver();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "AD OUT");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByServer();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "DEUCE");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByServer();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "AD IN");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByReceiver();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "DEUCE");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByReceiver();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "AD OUT");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByServer();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "DEUCE");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByServer();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
            score = scorer.GameScore.ToString();
            isScoreOk = String.Equals(score, "AD IN");
            Debug.Assert(isScoreOk, "Score failed");

            scorer.PointWonByServer();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(isGameOver, "False game ending");

            bool isServerWinner = scorer.IsServerGameWinner;
            Debug.Assert(isServerWinner, "Wrong winner");
        }
    }
}
