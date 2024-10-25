using Hangman.Methods;

namespace Hangman
{
    internal class Program
    {
        static string? Word;
        static int length;
        static string __Length = "";
        static int life = 7;
        static string? WGuess;
        static string? LGuess;

        static void Main(string[] args)
        {
            // Welcome class comes from Welcome.Cs
            Welcome welcome = new Welcome();
            chooseWord();
            playerGuess();
        }
            
        // chooseWord method is where the player give the word to the game.
        public static void chooseWord()
        {
            Console.Write("Enter your word: ");
            Word = Console.ReadLine()?.ToUpper();
            length = Word.Length;
            __Length = new string('_', length);
            Console.Clear();
        }

        //playerGuess method is where the player guesses and can choose between guess a word or letter. It also uses While and switch
        public static void playerGuess()
        {
            while (life > 0 && __Length.Contains('_'))
            {
                Console.WriteLine("Word Length is \n{0}", __Length);
                Console.WriteLine($"Lives remaining: {life}");

                Console.WriteLine("Choose between L for letter");
                Console.WriteLine("Choose between W for word");
                Console.WriteLine("\nWhat is your choice?");
                string? keycheck = Convert.ToString(Console.ReadLine())?.ToUpper();

                switch (keycheck)
                {
                    case "L":
                        Console.WriteLine("Guess a letter: ");
                        LGuess = Console.ReadLine()?.ToUpper();
                        if (LGuess != null && LGuess.Length == 1)
                        {
                            if (Word.Contains(LGuess))
                            {
                                for (int i = 0; i < Word.Length; i++)
                                {
                                    if (Word[i] == LGuess[0])
                                    {
                                        __Length = __Length.Remove(i, 1).Insert(i, LGuess);
                                    }
                                }
                            }
                            else
                            {
                                life--;
                            }
                        }
                        break;

                    case "W":
                        Console.WriteLine("Guess a word: ");
                        WGuess = Console.ReadLine()?.ToUpper();
                        if (WGuess == Word)
                        {
                            __Length = Word;
                        }
                        else
                        {
                            life--;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid answer, please choose 'L' or 'W'.");
                        break;
                }
            }

            if (__Length == Word)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCongratulations! You've guessed the word: {0}", Word);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nGame Over. The word was: {0}", Word);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
