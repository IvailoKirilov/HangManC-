# Hangman Game
This is a "HangMan" C# course project game, created by [Ivailo Kirilov](https://github.com/IvailoKirilov) (Our team leader), [Georgi Georgiev](https://github.com/gogo1701) (Our code writer), [Deyan Georgiev](https://github.com/DeyanGeorgiev223) (Presentator), [Kostadin Maistorov](https://github.com/USAAAAAAA) (Tester) and @SavaArabov (Documentary). Every role is chosen by our teacher Ivan Ivanov and below you will find everything that can answer your questions.
## HangMan Rules  

The game is simple. You will have a number of attempts depending on the difficulty you choose. The program will randomly select a word that you need to guess by suggesting letters that you think are in the word. Each mistake reduces your remaining attempts. When you run out of attempts, you lose, and the game will restart if you choose to play again.
## Content
### Structure of Project
* Classes
  - PlayerGraphics.cs
  - Words.cs
* Utility
  - words.txt
* Program.cs

## Classes
### PlayerGraphics.cs
PlayerGraphics is used for outputting almost everything seen on screen.

Methods in class:
* printWin() - Prints win screen.
* printLose() - Prints lose screen.
* printWrongGuessFrames(int number) - Prints wrong guess frames with the parameter being the choice.
* printDeathAnimation() - Prints the death animation played at loss.

### Words.cs
Words is used for getting our words and actions with those words.

Methods in class:
* getRandomWord() - Returns random word in words.txt file.
* CheckIfSymbolIsContained(string word, char playerLetter) - Checks if a symbol is contained in a word and returns bool based on result.
* getWordBasedOnDifficulty(int length) - Returns word that fits the amount of letters passed through length.
  
### Program.cs
Main game logic, combines every class for the game to work. The logic of the game is written in seperate methods, which are then called based on player input.
