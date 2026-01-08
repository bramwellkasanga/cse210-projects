using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = rand.Next(1, 101);
            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
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

            Console.WriteLine($"You guessed it in {guessCount} guesses!");

            Console.Write("Do you want to play again? ");
            string response = Console.ReadLine().ToLower();
            if (response != "yes")
            {
                playAgain = false;
            }
        }
    }
}