using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaniV4
{
    class Words
    {
        private string word;
        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public Words()
        {
            word = "";
        }

        public override string ToString()
        {
            return Word;
        }
    }
}
