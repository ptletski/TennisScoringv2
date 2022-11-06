using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scoreboard
{
    public class PlayerName
    {
        string _firstName;
        string _lastName;

        public PlayerName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FullName
        {
            get
            {
                return _firstName + " " + _lastName;
            }
        }

        public string LastNameFirst
        {
            get
            {
                return _lastName + ", " + _firstName;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }
    }
}
