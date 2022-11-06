using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Scoreboard
{
    public partial class MainWindow : Window
    {
        private void ClearMessage()
        {
            messageTxt.Text = String.Empty;
        }

        private void ZeroSetScore()
        {
            setPlayer1.Text = "0";
            setPlayer2.Text = "0";
        }

        private void ResetPlayerNames()
        {
            _namePlayer1 = new PlayerName("", "player1");
            _namePlayer2 = new PlayerName("", "player2");

            namePlayer1.Text = _namePlayer1.LastName;
            namePlayer2.Text = _namePlayer2.LastName;
        }

        private void ReadyToStartMatchButtons()
        {
            startMatchBtn.IsEnabled = true;
            startSetBtn.IsEnabled = false;
            startGameBtn.IsEnabled = false;
        }

        private void ReadyToStartSetButtons()
        {
            startMatchBtn.IsEnabled = false;
            startSetBtn.IsEnabled = true;
            startGameBtn.IsEnabled = false;
        }

        private void ReadyToStartGameButtons()
        {
            startMatchBtn.IsEnabled = false;
            startSetBtn.IsEnabled = false;
            startGameBtn.IsEnabled = true;
        }

        private void PlayingGameButtons()
        {
            startMatchBtn.IsEnabled = false;
            startSetBtn.IsEnabled = false;
            startGameBtn.IsEnabled = false;
        }

        private void MatchOverButtons()
        {
            PlayingGameButtons();
        }

        private void DisableSeries()
        {
            series2of3Btn.IsEnabled = false;
            series3of5Btn.IsEnabled = false;
        }

        private void EnableSeries()
        {
            series2of3Btn.IsEnabled = true;
            series3of5Btn.IsEnabled = true;
        }

        private void SetSeries2of3()
        {
            series2of3Btn.IsChecked = true;
            series3of5Btn.IsChecked = false;
        }

        private void ZeroScoreboard()
        {
            gamePlayer1.Text = "0";
            gamePlayer2.Text = "0";
            setPlayer1.Text = "0";
            setPlayer2.Text = "0";
            matchPlayer1.Text = "0";
            matchPlayer2.Text = "0";
        }

        private void HideServeIndicators()
        {
            player1serveImg.Visibility = Visibility.Hidden;
            player2serveImg.Visibility = Visibility.Hidden;
        }

        private void UpdateServerIndicator(ServingPlayer server)
        {
            if (server == ServingPlayer.Player1)
            {
                player1serveImg.Visibility = Visibility.Visible;
                player2serveImg.Visibility = Visibility.Hidden;
            }
            else
            {
                player1serveImg.Visibility = Visibility.Hidden;
                player2serveImg.Visibility = Visibility.Visible;
            }
        }

        private void DisableNamePlayers()
        {
            setPlayer1Btn.IsEnabled = false;
            setPlayer2Btn.IsEnabled = false;
        }

        private void EnableNamePlayers()
        {
            setPlayer1Btn.IsEnabled = true;
            setPlayer2Btn.IsEnabled = true;
        }

        private void DisableActionButtons()
        {
            faultByServerBtn.IsEnabled = false;
            letByServerBtn.IsEnabled = false;
            winnerByServerBtn.IsEnabled = false;
            winnerByReceiverBtn.IsEnabled = false;
            unforcedErrorServerBtn.IsEnabled = false;
            unforcedErrorRecieverBtn.IsEnabled = false;
            penalizeServerBtn.IsEnabled = false;
            penalizeReceiverBtn.IsEnabled = false;
        }

        private void EnableActionButtons()
        {
            faultByServerBtn.IsEnabled = true;
            letByServerBtn.IsEnabled = true;
            winnerByServerBtn.IsEnabled = true;
            winnerByReceiverBtn.IsEnabled = true;
            unforcedErrorServerBtn.IsEnabled = true;
            unforcedErrorRecieverBtn.IsEnabled = true;
            penalizeServerBtn.IsEnabled = true;
            penalizeReceiverBtn.IsEnabled = true;
        }

        private void UpdateScoreBoard(MatchState matchState)
        {
            gamePlayer1.Text = matchState.ScorePlayer1;
            gamePlayer2.Text = matchState.ScorePlayer2;
            setPlayer1.Text = matchState.GamesWonByPlayer1.ToString();
            setPlayer2.Text = matchState.GamesWonByPlayer2.ToString();
            matchPlayer1.Text = matchState.SetsWonByPlayer1.ToString();
            matchPlayer2.Text = matchState.SetsWonByPlayer2.ToString();

            UpdateServerIndicator(matchState.ServingPlayer);

            if (matchState.IsGameOver == true)
            {
                DisableActionButtons();
                ReadyToStartGameButtons();
            }

            if (matchState.IsSetOver == true)
            {
                ReadyToStartSetButtons();
            }

            if (matchState.IsMatchOver == true)
            {
                MatchOverButtons();
            }

            if (matchState.AdvantageScore.Length != 0)
            {
                messageTxt.Text = matchState.AdvantageScore + " ";
            }

            if (matchState.Message.Length != 0)
            {
                messageTxt.Text = matchState.Message;
            }
        }
    }
}
