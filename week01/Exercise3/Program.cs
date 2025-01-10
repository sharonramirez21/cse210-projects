using System;

class Program
{
    static void Main(string[] args)
    {
        /* PART 1- and 2
        Console.WriteLine("What is the magic number?: ");
        String MagicNumber = Console.ReadLine();
        int number = int.Parse(MagicNumber);*/

        Random randomGenerator = new Random();
        int MagicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        
        while (guess != MagicNumber)
        {
            Console.WriteLine("What is your guess?: ");
            String numberuser = Console.ReadLine();
            guess = int.Parse(numberuser);
            
            if (MagicNumber < guess)
            {
                Console.WriteLine("The number is lower!");
            }
            else if (MagicNumber > guess)
            {
                Console.WriteLine("The number is higher!");
            }
            else
            {
                Console.WriteLine("Congratulations, you guessed it!");
            }
        }
    }
}