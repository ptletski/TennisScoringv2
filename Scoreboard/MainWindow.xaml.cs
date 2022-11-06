using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scoreboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TennisController _controller;
        PlayerName _namePlayer1;
        PlayerName _namePlayer2;

        public MainWindow()
        {
            InitializeComponent();
            InitializeState();
        }

        private void InitializeState()
        {
            _controller = new TennisController();

            ReadyToStartMatchButtons();
            ResetPlayerNames();
            SetSeries2of3();
            ZeroScoreboard();
            HideServeIndicators();
            EnableNamePlayers();
            DisableActionButtons();
            ReadyToStartMatchButtons();
            ClearMessage();
        }
    }
}
