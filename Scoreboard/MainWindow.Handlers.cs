using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;

namespace Scoreboard
{
    public partial class MainWindow : Window
    {
        private void setPlayer1Btn_Click(object sender, RoutedEventArgs e)
        {
            PlayerNameEntryWindow entryDialog = new PlayerNameEntryWindow(PlaneNameEntryMode.Player1);

            entryDialog.Owner = this;
            entryDialog.ShowDialog();

            if (entryDialog.DialogResult == true)
            {
                _namePlayer1 = entryDialog.PlayerName;
                namePlayer1.Text = _namePlayer1.LastNameFirst;
            }
        }

        private void setPlayer2Btn_Click(object sender, RoutedEventArgs e)
        {
            PlayerNameEntryWindow entryDialog = new PlayerNameEntryWindow(PlaneNameEntryMode.Player2);

            entryDialog.Owner = this;
            entryDialog.ShowDialog();

            if (entryDialog.DialogResult == true)
            {
                _namePlayer2 = entryDialog.PlayerName;
                namePlayer2.Text = _namePlayer2.LastNameFirst;
            }
        }

        private void startMatchBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchGameSeries series = (series2of3Btn.IsChecked == true) ?
                MatchGameSeries.Best2of3 :
                MatchGameSeries.Best3of5;

            ServingPlayer server = _controller.BeginMatch(_namePlayer1, _namePlayer2, series);
            
            UpdateServerIndicator(server);
            ReadyToStartSetButtons();
            DisableSeries();
            DisableNamePlayers();
        }

        private void startSetBtn_Click(object sender, RoutedEventArgs e)
        {
            _controller.BeginSet();

            ZeroSetScore();
            ReadyToStartGameButtons();
        }

        private void startGameBtn_Click(object sender, RoutedEventArgs e)
        {
            _controller.BeginGame();

            PlayingGameButtons();
            EnableActionButtons();
            ClearMessage();
        }

        private void faultByServerBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchState matchState = _controller.FaultByServer();
            UpdateScoreBoard(matchState);
        }

        private void letByServerBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchState matchState = _controller.LetByServer();
            UpdateScoreBoard(matchState);
        }

        private void winnerByServerBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchState matchState = _controller.WinnerByServer();
            UpdateScoreBoard(matchState);
        }

        private void unforcedErrorByServerBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchState matchState = _controller.UnforcedErrorByServer();
            UpdateScoreBoard(matchState);
        }

        private void penalizeServerBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchState matchState = _controller.PenalizeServer();
            UpdateScoreBoard(matchState);
        }

        private void winnerByReceiverBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchState matchState = _controller.WinnerByReceiver();
            UpdateScoreBoard(matchState);
        }

        private void unforcedErrorByReceiverBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchState matchState = _controller.UnforcedErrorByReceiver();
            UpdateScoreBoard(matchState);
        }

        private void penalizeReceiverBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchState matchState = _controller.PenalizeReceiver();
            UpdateScoreBoard(matchState);
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            InitializeState();
        }

    }
}
