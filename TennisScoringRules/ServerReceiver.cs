using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoringRules
{
    public struct ServerReceiver
    {
        Player _server;
        Player _receiver;

        public Player Server
        {
            get
            {
                return _server;
            }

            set
            {
                _server = value;
            }
        }

        public Player Receiver
        {
            get
            {
                return _receiver;
            }

            set
            {
                _receiver = value;
            }
        }

        public void Flip()
        {
            Player temp = _server;
            
            _server = _receiver;
            _receiver = temp;
        }
    }
}
