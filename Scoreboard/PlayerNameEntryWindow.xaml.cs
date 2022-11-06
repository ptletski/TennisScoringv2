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
using System.Windows.Shapes;

namespace Scoreboard
{
    public enum PlaneNameEntryMode { Player1, Player2 };
    public enum ModalDialogResult { OK, Cancel };

    public partial class PlayerNameEntryWindow : Window
    {
        ModalDialogResult _result;
        string _playerFirstName;
        string _playerLastName;

        public PlayerNameEntryWindow(PlaneNameEntryMode mode)
        {
            Result = ModalDialogResult.Cancel;

            InitializeComponent();

            string player = (mode == PlaneNameEntryMode.Player1) ? "1" : "2";

            nameEntryPrompt.Text = "Enter the name for Player " + player;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            _playerFirstName = firstNameTxt.Text;
            _playerLastName = lastNameTxt.Text; 

            if (_playerLastName.Length != 0 && _playerFirstName.Length != 0)
            {   
                Result = ModalDialogResult.OK;

                DialogResult = true;
            }
        }

        public ModalDialogResult Result
        {
            get
            {
                return _result;
            }

            private set
            {
                _result = value;
            }
        }

        public PlayerName PlayerName
        {
            get
            {
                if (DialogResult == true)
                {
                    PlayerName playerName = new PlayerName(_playerFirstName, _playerLastName);
                    return playerName;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
