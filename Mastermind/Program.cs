using System;
using System.Runtime.ConstrainedExecution;

namespace Mastermind
{
    class Program
    {

        static void Main(string[] args)
        {
            //create code for this game
            Code code = new Code();
            //boolean to indicate if the player has guessed correctly and won
            Boolean won = false;
            //guess number that the player is on
            int guessNum = 0;

            Console.WriteLine("Hello and welcome to Mastermind, you have 10 guesses. Good luck!\n");

            //game loop of 10 guesses
            while (!won && (guessNum < 10))
            {
                String readIn = "";
                //keep letting the user guess until they guess in a valid format
                do
                {
                    Console.Write("Guess " + (guessNum + 1) + ": ");
                    readIn = Console.ReadLine();
                } while (!goodInput(readIn));
                
                //format the user's input for easier evaluation
                int[] guess = formatInput(readIn);

                String hint = code.checkGuess(guess);
                if (hint.Equals("++++"))
                {
                    won = true;
                } else
                {
                    Console.WriteLine(hint);
                    Console.WriteLine();
                }

                guessNum++;
            } //end of guessing loop

            //finish the game based on whether the player won or not
            if (won)
            {
                Console.WriteLine("\nCongratulations! You beat Mastermind!");
            }
            else
            {
                Console.WriteLine("\nSorry, you've run out of guesses. The code was " + code.getCode() + ". Better luck next time!");
            }
        }

        //checks the user input to make sure it is a number with four digits
        //all four digits should be between 1-6
        //inputs true for a valid input and false otherwise
        //prints an error message if applicable when called
        public static Boolean goodInput(string guess)
        {
            int g; 
            if (!int.TryParse(guess, out g))
            {
                Console.WriteLine("Your input must be a number\n");
                return false;
            } else
            {
                //check for 4 digits
                if (guess.Length != 4)
                {
                    Console.WriteLine("Your input must be four digits long\n");
                    return false;
                }

                int[] guessArray = formatInput(guess);

                //check that all of the digits are between 1 and 6
                for (int i=0; i<4; i++)
                {
                    if (guessArray[i] < 1 || guessArray[i] > 6)
                    {
                        Console.WriteLine("Digits must be between 1 and 6\n");
                        return false;
                    }
                }
            }

            return true;
        }

        //takes in a user input as a string and makes it an array for easier use
        public static int[] formatInput(string guess)
        {
            int[] guessArray = new int[guess.Length];
            int g = Convert.ToInt32(guess);
            
            for (int i=guess.Length - 1; i >= 0; i--)
            {
                guessArray[i] = g % 10;
                g /= 10;
            }
            
            return guessArray;
        }
    }
}
