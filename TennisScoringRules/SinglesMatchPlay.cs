using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoringRules
{
    public class SinglesMatchPlay
    {
        enum Coin { Heads, Tails };

        Player _player1;
        Player _player2;

        Player _server;
        Player _receiver;

        ISinglesMatchScorer _matchScorer;

        public SinglesMatchPlay(
            Player player1, 
            Player player2, 
            ISinglesMatchScorer scorer)
        {
            _player1 = player1;
            _player2 = player2;

            _matchScorer = scorer;
        }

        public ServerReceiver BeginMatch()
        {
            _matchScorer.BeginMatch();

            if (CoinToss() == Coin.Heads)
            {
                _server = _player1;
                _receiver = _player2;
            }
            else
            {
                _server = _player2;
                _receiver = _player1;
            }

            ServerReceiver result = new ServerReceiver();

            result.Server = _server;
            result.Receiver = _receiver;

            return result;
        }

        public bool IsMatchOver
        {
            get
            {
                return _matchScorer.IsMatchOver;
            }
        }

        public void BeginSet()
        {
            _matchScorer.BeginSet();
        }

        public bool IsSetOver
        {
            get
            {
                return _matchScorer.IsSetOver;
            }
        }

        private Coin CoinToss()
        {
            int coinToss = new Random().Next(10);

            return ((coinToss % 2) == 0) ? Coin.Heads : Coin.Tails;
        }
    }
}
