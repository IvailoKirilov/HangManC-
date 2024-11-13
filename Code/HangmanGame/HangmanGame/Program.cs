using HangmanGame.Classes;

// get classes
PlayerGraphics playergraphics = new PlayerGraphics();
Words words = new Words();

// Remove CursorVisible
Console.CursorVisible = false;

// constant values
const char Underscore = '_';

// methods
void DrawCurrentGameState(bool inputIsInvalid, int incorrectGuess, string guessedWord, List<char> playerUsedLetters)
{
    if (!inputIsInvalid)
    {
        playergraphics.printWrongGuessFrames(incorrectGuess);
        Console.WriteLine($"Word: {guessedWord}");
        Console.WriteLine($"Guessed letters: {string.Join(' ', playerUsedLetters)}");
    }
}

string AddLetterToGuessWord(string word, char playerLetter, string wordToGuess)
{
    char[] wordToGuessCharArr = wordToGuess.ToCharArray();

    for(int i = 0; i < wordToGuess.Length; i++)
    {
        if(playerLetter == word[i])
        {
            wordToGuessCharArr[i] = playerLetter;
        }
    }

    return new String(wordToGuessCharArr);
}

bool CheckIfPlayerWins(string wordToGuess)
{
    if (wordToGuess.Contains(Underscore))
    {
        return false;
    }

    return true;
}

bool CheckIfPlayerLoses(int incorrectGuessCount)
{
    const int MaxAllowedIncorrectCharacters = 6;
    if(incorrectGuessCount == MaxAllowedIncorrectCharacters)
    {
        return true;
    }
    return false;
}

void PlayGame(string word, string wordToGuess, int incorrectGuessCount, List<char> playerUsedLetters)
{
    while (true)
    {
        string playerInput = Console.ReadLine().ToLower();

        if(playerInput.Length != 1) {
            char playerLetter = char.Parse(playerInput);
            playerUsedLetters.Add(playerLetter);

            bool playerLetterIsContained = words.CheckIfSymbolIsContained(word, playerLetter);

            if (playerLetterIsContained)
            {
                wordToGuess = AddLetterToGuessWord(word, playerLetter, wordToGuess);
            }
            else
            {
                incorrectGuessCount++;
            }

            DrawCurrentGameState(true, incorrectGuessCount, wordToGuess, playerUsedLetters);
            bool playerWins = CheckIfPlayerWins(wordToGuess);
            if (playerWins) {
                Console.Clear();
                playergraphics.printWin();
                Console.WriteLine($"The word you guessed is [{word}].");

                break;
            }
            bool playerLoses = CheckIfPlayerLoses(incorrectGuessCount);
            if(playerLoses) {
                Console.SetCursorPosition(0, 0);

                playergraphics.printDeathAnimation();
                Console.Clear();
                playergraphics.printLose();
                Console.WriteLine($"The exact word is [{word}].");
            }

        }
    }
}

while (true)
{
    string word = words.getRandomWord();
    string wordToGuess = new(Underscore, word.Length);

    int incorrectGuessCount = 0;
    List<char> playerUsedLetters= new List<char>();

    DrawCurrentGameState(false, incorrectGuessCount, wordToGuess, playerUsedLetters);
    PlayGame(word, wordToGuess, incorrectGuessCount, playerUsedLetters);


    Console.Write("If you want to play again, press [Enter]. Else, type 'quit': ");
    string playerInput = Console.ReadLine();

    if(playerInput == "quit")
    {
        Console.Clear();
        Console.WriteLine("Thank you for playing! Hangman was closed.");
        break;
    }

    Console.Clear();
}