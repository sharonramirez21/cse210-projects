using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name?");
        String name = Console.ReadLine();

        Console.WriteLine("What is your last name?");
        String last_name = Console.ReadLine();

        Console.WriteLine($"Your name is: {name} {last_name}");
    }
}