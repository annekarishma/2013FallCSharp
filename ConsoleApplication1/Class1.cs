using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample1
{
    public class Dog
    {
        #region "Fields"
        private List<string> _listOfWords = new List<string>();
        private string _dogsWord = "woof";
        private int _speed;
        #endregion

        #region "Properties"
        public string DogsWord
        {
            get { return _dogsWord; }
            set { _dogsWord = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        #endregion

        #region "Methods"
        //[Obsolete]: For public API: let the users not to use this method anymore
        public string Bark()
        {
            //return _dogsWord;
            return _dogsWord + string.Join(", ", _listOfWords);
        }

        public string Run()
        {
            return "I am running at " + _speed + " Miles an Hour.";
        }

        public void LearnNewWord(string word)
        {
            _listOfWords.Add(word);
        }
        #endregion

    }
}
