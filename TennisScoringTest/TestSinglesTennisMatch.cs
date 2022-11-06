using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisScoringRules;
using System.Diagnostics;

namespace TennisScoringTest
{
    internal class TestSinglesTennisMatch
    {
        public static void ExecuteTestSuite()
        {
            //TestBeginMatch();
            //TestBeginSet();
            //TestFirstCompleteSet();
            TestFirstCompleteMatch2of3();
        }

        public static void TestBeginMatch()
        {
            Player player1 = new Player("Paul", "T", "USTA", "OHIO", "2.5 Men Over 50");
            Player player2 = new Player("Margo", "VD", "USTA", "OHIO", "4.5 Women Over 50");

            GameScorer gameScorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(gameScorer);

            SinglesMatchScorer matchScorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);
            SinglesMatchPlay matchPlay = new SinglesMatchPlay(player1, player2, matchScorer);

            // -------------

            ServerReceiver serverReceiver = matchPlay.BeginMatch();
            bool isMatchOver = matchPlay.IsMatchOver;

            Debug.Assert(!isMatchOver, "Match should not be over");
        }

        public static void TestBeginSet()
        {
            Player player1 = new Player("Paul", "T", "USTA", "OHIO", "2.5 Men Over 50");
            Player player2 = new Player("Margo", "VD", "USTA", "OHIO", "4.5 Women Over 50");

            GameScorer gameScorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(gameScorer);

            SinglesMatchScorer matchScorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);
            SinglesMatchPlay matchPlay = new SinglesMatchPlay(player1, player2, matchScorer);

            // -------------

            ServerReceiver serverReceiver = matchPlay.BeginMatch();
            bool isMatchOver = matchPlay.IsMatchOver;

            Debug.Assert(!isMatchOver, "Match should not be over");

            matchPlay.BeginSet();
            bool isSetOver = matchPlay.IsSetOver;

            Debug.Assert(!isSetOver, "Set should not be over");
        }

        public static void TestFirstCompleteSet()
        {
            Player player1 = new Player("Paul", "T", "USTA", "OHIO", "2.5 Men Over 50");
            Player player2 = new Player("Margo", "VD", "USTA", "OHIO", "4.5 Women Over 50");

            GameScorer gameScorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(gameScorer);

            SinglesMatchScorer matchScorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);
            SinglesMatchPlay matchPlay = new SinglesMatchPlay(player1, player2, matchScorer);

            // -------------

            ServerReceiver serverReceiver = matchPlay.BeginMatch();

            Console.WriteLine("Server: {0}, Receiver: {1}\n", 
                serverReceiver.Server.FullName, 
                serverReceiver.Receiver.FullName);

            bool isMatchOver = matchPlay.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");
            string matchScore = matchScorer.ScoreOfMatch.ToString();
            bool isMatchScoreRight = String.Equals(matchScore, "0-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");
            Console.WriteLine("Match Score {0} - {1}\n{2}\n", player1.FullName, player2.FullName, matchScore);

            PlayCompleteSetSkunk(serverReceiver, gamePlay, player1, player2, matchScorer, matchPlay);
            matchScore = matchScorer.ScoreOfMatch.ToString();
            Console.WriteLine("Match Score {0} - {1}\n{2}\n", player1.FullName, player2.FullName, matchScore);
        }

        public static void TestFirstCompleteMatch2of3()
        {
            Player player1 = new Player("Paul", "T", "USTA", "OHIO", "2.5 Men Over 50");
            Player player2 = new Player("Margo", "VD", "USTA", "OHIO", "4.5 Women Over 50");

            GameScorer gameScorer = new GameScorer();
            GamePlay gamePlay = new GamePlay(gameScorer);

            SinglesMatchScorer matchScorer = new SinglesMatchScorer(MatchSeries.TwoOfThree);
            SinglesMatchPlay matchPlay = new SinglesMatchPlay(player1, player2, matchScorer);

            // -------------

            ServerReceiver serverReceiver = matchPlay.BeginMatch();

            Console.WriteLine("Server: {0}, Receiver: {1}\n",
                serverReceiver.Server.FullName,
                serverReceiver.Receiver.FullName);

            bool isMatchOver = matchPlay.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");
            string matchScore = matchScorer.ScoreOfMatch.ToString();
            bool isMatchScoreRight = String.Equals(matchScore, "0-0");
            Debug.Assert(isMatchScoreRight, "Match score is wrong");
            Console.WriteLine("Match Score {0} - {1}\n{2}\n", player1.FullName, player2.FullName, matchScore);

            PlayCompleteSetSkunk(serverReceiver, gamePlay, player1, player2, matchScorer, matchPlay);
            matchScore = matchScorer.ScoreOfMatch.ToString();
            Console.WriteLine("Match Score {0} - {1}\n{2}\n", player1.FullName, player2.FullName, matchScore);

            isMatchOver = matchPlay.IsMatchOver;
            Debug.Assert(!isMatchOver, "Match should not be over");

            PlayCompleteSetSkunk(serverReceiver, gamePlay, player1, player2, matchScorer, matchPlay);
            matchScore = matchScorer.ScoreOfMatch.ToString();
            Console.WriteLine("Match Score {0} - {1}\n{2}\n", player1.FullName, player2.FullName, matchScore);

            isMatchOver = matchPlay.IsMatchOver;
            Debug.Assert(isMatchOver, "Match should be over");

            string matchWinner = matchScorer.IsMatchWinnerPlayer1 ?
                player1.FullName :
                player2.FullName;

            Console.WriteLine("Match is over. Winner is {0}\n", matchWinner);
        }

        private static void PlayCompleteSetSkunk(
                ServerReceiver serverReceiver,
                GamePlay gamePlay,
                Player player1,
                Player player2,
                SinglesMatchScorer matchScorer,
                SinglesMatchPlay matchPlay)
        {
            matchPlay.BeginSet();
            bool isSetOver = matchPlay.IsSetOver;
            Debug.Assert(!isSetOver, "Set should not be over");

            string setScore = matchScorer.ScoreOfSet.ToString();
            bool isSetScoreRight = String.Equals(setScore, "0-0");
            Debug.Assert(isSetScoreRight, "Set score is wrong");

            // -------------

            PlayCompleteGameServerSkunk(serverReceiver, gamePlay);
            CreditGameWinnerForSet(serverReceiver, gamePlay, player1, player2, matchScorer);
            setScore = matchScorer.ScoreOfSet.ToString();
            Console.WriteLine("{0} - {1}\n{2}\n", player1.FullName, player2.FullName, setScore);
            serverReceiver.Flip();

            PlayCompleteGameReceiverSkunk(serverReceiver, gamePlay);
            CreditGameWinnerForSet(serverReceiver, gamePlay, player1, player2, matchScorer);
            setScore = matchScorer.ScoreOfSet.ToString();
            Console.WriteLine("{0} - {1}\n{2}\n", player1.FullName, player2.FullName, setScore);
            serverReceiver.Flip();

            PlayCompleteGameServerSkunk(serverReceiver, gamePlay);
            CreditGameWinnerForSet(serverReceiver, gamePlay, player1, player2, matchScorer);
            setScore = matchScorer.ScoreOfSet.ToString();
            Console.WriteLine("{0} - {1}\n{2}\n", player1.FullName, player2.FullName, setScore);
            serverReceiver.Flip();

            PlayCompleteGameReceiverSkunk(serverReceiver, gamePlay);
            CreditGameWinnerForSet(serverReceiver, gamePlay, player1, player2, matchScorer);
            setScore = matchScorer.ScoreOfSet.ToString();
            Console.WriteLine("{0} - {1}\n{2}\n", player1.FullName, player2.FullName, setScore);
            serverReceiver.Flip();

            PlayCompleteGameServerSkunk(serverReceiver, gamePlay);
            CreditGameWinnerForSet(serverReceiver, gamePlay, player1, player2, matchScorer);
            setScore = matchScorer.ScoreOfSet.ToString();
            Console.WriteLine("{0} - {1}\n{2}\n", player1.FullName, player2.FullName, setScore);
            serverReceiver.Flip();

            PlayCompleteGameReceiverSkunk(serverReceiver, gamePlay);
            CreditGameWinnerForSet(serverReceiver, gamePlay, player1, player2, matchScorer);
            setScore = matchScorer.ScoreOfSet.ToString();
            Console.WriteLine("{0} - {1}\n{2}\n", player1.FullName, player2.FullName, setScore);

            isSetOver = matchPlay.IsSetOver;
            Debug.Assert(isSetOver, "Set should be over");
        }

        private static void CreditGameWinnerForSet(
                ServerReceiver serverReceiver, 
                GamePlay gamePlay,
                Player player1,
                Player player2,
                SinglesMatchScorer matchScorer)
        {
            if (gamePlay.IsServerGameWinner == true)
            {
                Player player = serverReceiver.Server;

                if (player == player1)
                {
                    matchScorer.GameWonByPlayer1();
                }
                else
                {
                    matchScorer.GameWonByPlayer2();
                }
            }
            else
            {
                Player player = serverReceiver.Receiver;

                if (player == player1)
                {
                    matchScorer.GameWonByPlayer1();
                }
                else
                {
                    matchScorer.GameWonByPlayer2();
                }
            }
        }

        private static void PlayCompleteGameServerSkunk(
            ServerReceiver serverReceiver,
            GamePlay gamePlay)
        {
            gamePlay.BeginGame();

            string score = gamePlay.GameScore.ToString();
            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByServer();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "15-0");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            Console.WriteLine("Server: {0}, Receiver: {1}\nScore: {2}\n",
                serverReceiver.Server.FullName,
                serverReceiver.Receiver.FullName,
                score);

            gamePlay.UnforcedErrorByReceiver();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "30-0");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            Console.WriteLine("Server: {0}, Receiver: {1}\nScore: {2}\n",
                serverReceiver.Server.FullName,
                serverReceiver.Receiver.FullName,
                score);

            gamePlay.UnforcedErrorByReceiver();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "40-0");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            Console.WriteLine("Server: {0}, Receiver: {1}\nScore: {2}\n",
                serverReceiver.Server.FullName,
                serverReceiver.Receiver.FullName,
                score);

            gamePlay.UnforcedErrorByReceiver();
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(isGameOver, "False game ending");

            bool isServerWinner = gamePlay.IsServerGameWinner;
            Debug.Assert(isServerWinner, "Wrong winner");

            bool isReceiverWinner = gamePlay.IsReceiverGameWinner;
            Debug.Assert(!isReceiverWinner, "Wrong winner");

            if (isGameOver == true)
            {
                string winnerName = (gamePlay.IsServerGameWinner) ?
                    serverReceiver.Server.FullName :
                    serverReceiver.Receiver.FullName;

                Console.WriteLine("Game Over: {0}\nWinner: {1}\n", score, winnerName);
            }
        }

        private static void PlayCompleteGameReceiverSkunk(
            ServerReceiver serverReceiver,
            GamePlay gamePlay)
        {
            gamePlay.BeginGame();

            string score = gamePlay.GameScore.ToString();
            bool isScoreOk = String.Equals(score, "0-0");
            Debug.Assert(isScoreOk, "Score failed");

            bool isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            gamePlay.WinnerByReceiver();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-15");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            Console.WriteLine("Server: {0}, Receiver: {1}\nScore: {2}\n",
                serverReceiver.Server.FullName,
                serverReceiver.Receiver.FullName,
                score);

            gamePlay.UnforcedErrorByServer();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-30");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            Console.WriteLine("Server: {0}, Receiver: {1}\nScore: {2}\n",
                serverReceiver.Server.FullName,
                serverReceiver.Receiver.FullName,
                score);

            gamePlay.UnforcedErrorByServer();
            score = gamePlay.GameScore.ToString();
            isScoreOk = String.Equals(score, "0-40");
            Debug.Assert(isScoreOk, "Score failed");
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(!isGameOver, "False game ending");

            Console.WriteLine("Server: {0}, Receiver: {1}\nScore: {2}\n",
                serverReceiver.Server.FullName,
                serverReceiver.Receiver.FullName,
                score);

            gamePlay.UnforcedErrorByServer();
            isGameOver = gamePlay.IsGameOver;
            Debug.Assert(isGameOver, "False game ending");

            bool isServerWinner = gamePlay.IsServerGameWinner;
            Debug.Assert(!isServerWinner, "Wrong winner");

            bool isReceiverWinner = gamePlay.IsReceiverGameWinner;
            Debug.Assert(isReceiverWinner, "Wrong winner");

            if (isGameOver == true)
            {
                string winnerName = (gamePlay.IsServerGameWinner) ?
                    serverReceiver.Server.FullName :
                    serverReceiver.Receiver.FullName;

                Console.WriteLine("Game Over: {0}\nWinner: {1}\n", score, winnerName);
            }
        }
    }
}
