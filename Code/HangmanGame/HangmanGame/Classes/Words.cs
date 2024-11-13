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
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            const string WordsFileName = "words.txt";
            string path = $@"{projectDirectory}\Utility\{WordsFileName}";

            string[] words = File.ReadAllLines(path);
            Random rng = new Random();

            int rngNumber = rng.Next(words.Length);

            return words[rngNumber];
        }
    }
}
