using System;


class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            // Generate a random magic number from 1 to 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("Guess My Number!");

            // Keep asking for guesses until the correct number is guessed
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                // Count the guess
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Display the number of guesses
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? 'yes' or 'no': ");
            playAgain = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Thanks for playing!");
    }
}
    