using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Words
    {
        private string[] guess;
        public string[] Guess
        {
            get { return guess; }
            set { guess = value; }
        }

        private string[] under;
        public string[] Under
        {
            get { return under; }
            set { under = value; }
        }
    }
}
