using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.Classes
{
    internal class Words
    {
        public string getRandomWord()
        {
            string line = null;
            StreamReader sr = new StreamReader("C:\\Sample.txt");
            List<string> words = new List<string>();

            while (line != null)
            {
                line = sr.ReadLine();

            }

            return;
        }
    }
}
