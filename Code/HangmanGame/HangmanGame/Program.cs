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

    for (int i = 0; i < wordToGuess.Length; i++)
    {
        if (playerLetter == word[i])
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
    if (incorrectGuessCount == MaxAllowedIncorrectCharacters)
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

        if (playerInput.Length == 1)
        {
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
            Console.Clear();
            DrawCurrentGameState(false, incorrectGuessCount, wordToGuess, playerUsedLetters);

            bool playerWins = CheckIfPlayerWins(wordToGuess);
            if (playerWins)
            {
                Console.Clear();
                playergraphics.printWin();
                Console.WriteLine($"The word you guessed is [{word}].");

                Thread.Sleep(5000);

                break;
            }
            bool playerLoses = CheckIfPlayerLoses(incorrectGuessCount);
            if (playerLoses)
            {
                Console.SetCursorPosition(0, 0);

                playergraphics.printDeathAnimation();
                Console.Clear();
                playergraphics.printLose();
                Console.WriteLine($"The exact word is [{word}].");

                Thread.Sleep(5000);

                break;
            }

        }
    }
}

static void DisplayMainMenu()
{
    Console.WriteLine("=== HANGMAN GAME ===");
    Console.WriteLine("1. Play Game");
    Console.WriteLine("2. Settings");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option: ");
}

static void DrawHeader(string title)
{
    Console.WriteLine(new string('=', 40));
    Console.WriteLine($"          {title}");
    Console.WriteLine(new string('=', 40));
}

static int SelectDifficulty()
{
    Console.Clear();
    DrawHeader("SELECT DIFFICULTY");
    Console.WriteLine("╔══════════════════════════════════╗");
    Console.WriteLine("║          DIFFICULTY LEVEL        ║");
    Console.WriteLine("╠══════════════════════════════════╣");
    Console.WriteLine("║  Enter how much letters the word ║");
    Console.WriteLine("║       you want to play has       ║");
    Console.WriteLine("╚══════════════════════════════════╝");
    Console.Write("Choose word length (3-13): ");

    int choice = int.Parse(Console.ReadLine());

    Console.Clear();
    if (choice < 3)
    {
        return 3;
    }
    else if (choice > 13)
    {
        return 13;
    }

    return choice;
}

static void ChangeSettings()
{
    Console.Clear();
    Console.WriteLine("=== Settings ===");
    Console.WriteLine("1. Change Text Color");
    Console.WriteLine("2. Change Background Color");
    Console.WriteLine("3. Back to Main Menu");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();
    if (choice == "1")
    {
        ChangeTextColor();
    }
    else if (choice == "2")
    {
        ChangeBackgroundColor();
    }
}

static void ChangeTextColor()
{
    Console.Clear();
    Console.WriteLine("Select Text Color:");
    foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
    {
        Console.WriteLine($"{(int)color}. {color}");
    }
    Console.Write("Enter color number: ");
    if (int.TryParse(Console.ReadLine(), out int colorValue) && Enum.IsDefined(typeof(ConsoleColor), colorValue))
    {
        Console.ForegroundColor = (ConsoleColor)colorValue;
    }
    else
    {
        Console.WriteLine("Invalid color. Press any key to try again.");
        Console.ReadKey();
    }
    Console.Clear();
}

static void ChangeBackgroundColor()
{
    Console.Clear();
    Console.WriteLine("Select Background Color:");
    foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
    {
        Console.WriteLine($"{(int)color}. {color}");
    }
    Console.Write("Enter color number: ");
    if (int.TryParse(Console.ReadLine(), out int colorValue) && Enum.IsDefined(typeof(ConsoleColor), colorValue))
    {
        Console.BackgroundColor = (ConsoleColor)colorValue;
        Console.Clear();
    }
    else
    {
        Console.WriteLine("Invalid color. Press any key to try again.");
        Console.ReadKey();
    }
    Console.Clear();

}


while (true)
{
    Console.WriteLine("Hangman Game");
    Console.WriteLine("1. Play Game");
    Console.WriteLine("2. Change Settings");
    Console.WriteLine("3. Exit");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            List<char> guessedLetters = new List<char>();
            string word = words.getWordBasedOnDifficulty(SelectDifficulty());
            int incorrectGuessCount = 0;

            string wordToGuess = new string('_', word.Length);
            List<char> playerUsedLetters = new List<char>();

            DrawCurrentGameState(false, incorrectGuessCount, wordToGuess, playerUsedLetters);
            PlayGame(word, wordToGuess, incorrectGuessCount, playerUsedLetters);

            Console.Write("If you want to play again, press [Enter]. Else, type 'quit': ");
            string playerInput = Console.ReadLine();
            Console.WriteLine(playerInput);
            if (playerInput == "quit")
            {
                Console.Clear();
                Console.WriteLine("Thank you for playing! Hangman was closed.");
                return;
            }
            Console.Clear();
            break;

        case "2":
            ChangeSettings();
            break;

        case "3":
            Console.WriteLine("Thank you for playing! Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid choice. Press any key to try again.");
            Console.ReadKey();
            Console.Clear();
            break;
    }
}
