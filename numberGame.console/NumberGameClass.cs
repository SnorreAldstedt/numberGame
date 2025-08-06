using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numberGame.console
{
    public class NumberGameClass
    {
        private int _number = 0;
        private int _count = 0;
        private int _maxGuesses = 100;

        public NumberGameClass(int number)
        {
            _number = number;
        }

        public NumberGameClass(int number, int maxGuesses)
        {
            _number = number;
            _maxGuesses = maxGuesses;
        }

        private string higherOrLower(int numberGuess, int correctNumber)
        {
            if (numberGuess == correctNumber)
            {
                return "Correct guess!";
            }
            else if (numberGuess > correctNumber)
            {
                return "Number is lower!";
            }
            else
            {
                return "Number is higher!";
            }
        }

        public void Start()
        {
            while (true)
            {
                if (_count >= _maxGuesses) 
                {
                    Console.WriteLine("You failed :(");
                    break; 
                }
                Console.WriteLine($"You have {_maxGuesses-_count} guess(es) left...");
                _count++;
                Console.WriteLine("Guess a number!(q to quit)");
                string guessInput = Console.ReadLine();

                if (guessInput == "q") { break; }
                else
                {
                    try
                    {
                        int guessNumber = int.Parse(guessInput);
                        Console.WriteLine(higherOrLower(guessNumber, _number));
                        if (guessNumber == _number)
                        {
                            Console.WriteLine($"You used {_count} guesses.");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"Failed parsing input");
                        _count -= 1;
                        continue;
                    }
                }
            }
        }
    }
}
