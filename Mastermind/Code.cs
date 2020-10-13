using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    class Code
    {
        private int[] code;

        //fill a 4 digit code with integers between 1 and 6
        public Code()
        {
            System.Random rand = new System.Random();
            code = new int[4];
            for (int i = 0; i < 4; i++)
            {
                code[i] = rand.Next(1, 7);
            }
        }

        //checks the guess against the code
        //returns a string with + for every correct guess and - for every
        //  incorrectly placed guess
        public String checkGuess(int[] guess)
        {
            String printOut = "";
            //refers to a number in the guess being connected to a code number
            Boolean[] guessUsed = { false, false, false, false };
            //refers to a location in the code being accounted for in the printout
            Boolean[] locationMarked = { false, false, false, false };

            //loop through the guess to check if any are exactly correct
            for (int i = 0; i < 4; i++)
            {
                //print + if the digit is exactly correct
                if (guess[i] == code[i])
                {
                    printOut += "+";
                    guessUsed[i] = true;
                    locationMarked[i] = true;
                }
            }

            //loop through the guess to check if any are correct in the wrong spot
            for (int guessLocation = 0; guessLocation < 4; guessLocation++)
            {
                int codeLocation = 0;
                //if the guess has not been used then loop through the code until you find a match or get to the end
                while (guessUsed[guessLocation] == false && codeLocation < 4)
                {
                    //if that code number has not been marked and the guess is right
                    if (!locationMarked[codeLocation] && (guess[guessLocation] == code[codeLocation]))
                    {
                        guessUsed[guessLocation] = true;
                        locationMarked[codeLocation] = true;
                        printOut += "-";
                    }

                    codeLocation++;
                }
            }

            //return the string
            return (printOut);
        }

        public String getCode()
        {
            String c = "";
            for (int i = 0; i < 4; i++)
            {
                c += this.code[i];
            }

            return c;
        }
    }
    
}
