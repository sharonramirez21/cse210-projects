using System;
// Add an activity that helps the user analyze and find solutions to their problems.
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Problem-Solving");
            Console.WriteLine("5. Quit");
            Console.Write("Option: ");
            string choice = Console.ReadLine();
            Console.Clear(); 
            
            switch (choice)
            {
                case "1":
                    new BreatingActivity().Run();
                    break;
                case "2":
                    new ListingActivity().Run();
                    break;
                case "3":
                    new ReflectingActivity().Run();
                    break;
                case "4":
                    new ProblemSolvingActivity().Run();
                    break;
                case "5":
                    Console.WriteLine("¡See you!!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try Again.");
                    break;
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}