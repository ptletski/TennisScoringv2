using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisScoringRules;
using System.Diagnostics;

namespace TennisScoringTest
{
    internal class TestGamePlay
    {
        public static void ExecuteTestSuite()
        {
            TestStartGame();
            TestPlayServerLoveGame();
            TestPlayReceiverLoveGame();
            TestPlayReceiverErrorGame();
            TestPlayServerErrorGame();
            TestPlayServerDoubleFaultsGame();
        }

        public static void TestStartGame()
        {
            GameScorer scorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(scorer);

            gamePlay.BeginGame();
            
            string score = gamePlay.GameScore.ToString();
            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");
        }

        public static void TestPlayServerLoveGame()
        {
            GameScorer scorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(scorer);

            gamePlay.BeginGame();

            string score = gamePlay.GameScore.ToString();
            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByServer();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "15-0");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByServer();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "30-0");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByServer();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "40-0");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByServer();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(isGameOver, "False game ending");

            bool isServerWinner = gamePlay.IsServerGameWinner;
            Debug.Assert(isServerWinner, "Wrong winner");

            bool isReceiverWinner = gamePlay.IsReceiverGameWinner;
            Debug.Assert(!isReceiverWinner, "Wrong winner");
        }

        public static void TestPlayReceiverLoveGame()
        {
            GameScorer scorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(scorer);

            gamePlay.BeginGame();

            string score = gamePlay.GameScore.ToString();
            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByReceiver();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-15");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByReceiver();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-30");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByReceiver();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-40");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByReceiver();
            isGameOver = scorer.IsGameOver;
            Debug.Assert(isGameOver, "False game ending");

            bool isServerWinner = scorer.IsServerGameWinner;
            Debug.Assert(!isServerWinner, "Wrong winner");

            bool isReceiverWinner = scorer.IsReceiverGameWinner;
            Debug.Assert(isReceiverWinner, "Wrong winner");
        }

        public static void TestPlayReceiverErrorGame()
        {
            GameScorer scorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(scorer);

            gamePlay.BeginGame();

            string score = gamePlay.GameScore.ToString();
            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.UnforcedErrorByReceiver();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "15-0");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.UnforcedErrorByReceiver();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "30-0");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.UnforcedErrorByReceiver();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "40-0");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.UnforcedErrorByReceiver();
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(isGameOver, "False game ending");

            bool isServerWinner = scorer.IsServerGameWinner;
            Debug.Assert(isServerWinner, "Wrong winner");

            bool isReceiverWinner = scorer.IsReceiverGameWinner;
            Debug.Assert(!isReceiverWinner, "Wrong winner");
        }

        public static void TestPlayServerErrorGame()
        {
            GameScorer scorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(scorer);

            gamePlay.BeginGame();

            string score = gamePlay.GameScore.ToString();
            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.UnforcedErrorByServer();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-15");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.UnforcedErrorByServer();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-30");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.UnforcedErrorByServer();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-40");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.UnforcedErrorByServer();
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(isGameOver, "Game should be over");

            bool isServerWinner = scorer.IsServerGameWinner;
            Debug.Assert(!isServerWinner, "Wrong winner");

            bool isReceiverWinner = scorer.IsReceiverGameWinner;
            Debug.Assert(isReceiverWinner, "Wrong winner");
        }

        public static void TestPlayServerDoubleFaultsGame()
        {
            GameScorer scorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(scorer);

            gamePlay.BeginGame();

            string score = gamePlay.GameScore.ToString();
            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = scorer.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            string outcome = String.Empty;

            bool isDoubleFault = gamePlay.FaultByServer(ref outcome);
            Debug.Assert(!isDoubleFault, "Incorrect double fault");
            bool isServeCallOk = String.Equals(outcome, "Second Service");
            Debug.Assert(isServeCallOk, "Service call failed");

            isDoubleFault = gamePlay.FaultByServer(ref outcome);
            Debug.Assert(isDoubleFault, "Incorrect double fault");
            isServeCallOk = String.Equals(outcome, "Double Fault");
            Debug.Assert(isServeCallOk, "Service call failed");

            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-15");
            Debug.Assert(isScoreOk, "Score failed");

            isDoubleFault = gamePlay.FaultByServer(ref outcome);
            Debug.Assert(!isDoubleFault, "Incorrect double fault");
            isServeCallOk = String.Equals(outcome, "Second Service");
            Debug.Assert(isServeCallOk, "Service call failed");

            isDoubleFault = gamePlay.FaultByServer(ref outcome);
            Debug.Assert(isDoubleFault, "Incorrect double fault");
            isServeCallOk = String.Equals(outcome, "Double Fault");
            Debug.Assert(isServeCallOk, "Service call failed");

            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-30");
            Debug.Assert(isScoreOk, "Score failed");

            isDoubleFault = gamePlay.FaultByServer(ref outcome);
            Debug.Assert(!isDoubleFault, "Incorrect double fault");
            isServeCallOk = String.Equals(outcome, "Second Service");
            Debug.Assert(isServeCallOk, "Service call failed");

            isDoubleFault = gamePlay.FaultByServer(ref outcome);
            Debug.Assert(isDoubleFault, "Incorrect double fault");
            isServeCallOk = String.Equals(outcome, "Double Fault");
            Debug.Assert(isServeCallOk, "Service call failed");

            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-40");
            Debug.Assert(isScoreOk, "Score failed");

            isDoubleFault = gamePlay.FaultByServer(ref outcome);
            Debug.Assert(!isDoubleFault, "Incorrect double fault");
            isServeCallOk = String.Equals(outcome, "Second Service");
            Debug.Assert(isServeCallOk, "Service call failed");

            isDoubleFault = gamePlay.FaultByServer(ref outcome);
            Debug.Assert(isDoubleFault, "Incorrect double fault");
            isServeCallOk = String.Equals(outcome, "Double Fault");
            Debug.Assert(isServeCallOk, "Service call failed");

            isGameOver = scorer.IsGameOver;
            Debug.Assert(isGameOver, "Game should be over");

            bool isServerWinner = scorer.IsServerGameWinner;
            Debug.Assert(!isServerWinner, "Wrong winner");

            bool isReceiverWinner = scorer.IsReceiverGameWinner;
            Debug.Assert(isReceiverWinner, "Wrong winner");
        }
    }
}
