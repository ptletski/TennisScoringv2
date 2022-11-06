using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoringRules
{
    public class Player
    {
        string _firstName;
        string _lastName;
        string _association;
        string _location;
        string _rating;

        public Player(string firstName, 
                    string lastName, 
                    string association, 
                    string location,
                    string rating)
        {
            _firstName = firstName;
            _lastName = lastName;
            _association = association;
            _rating = rating;
            _location = location;
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

        public string Location
        {
            get
            {
                return _location;
            }
        }

        public string Rating
        {
            get
            {
                return _rating;
            }
        }
    }
}
