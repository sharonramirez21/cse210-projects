using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        // calling the functions
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        
        DisplayResult(userName, squaredNumber);
    }

    // #step 1
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        // #step 2
        static string PromptUserName()
        {
            Console.WriteLine("Please, enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        // #step3
        static int PromptUserNumber()
        {
            Console.WriteLine("Enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        // #step 4
        static int SquareNumber(int number)
        {
            int square = number * number;
            return square;
        }

        // #step 5
        static void DisplayResult(string name, int square)
        {
            Console.WriteLine($"{name}, the square of your number is {square}");
        }
}