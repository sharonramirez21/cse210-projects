using System;

class Program
{
    static void Main(string[] args)
    {

        /// What I did as a stretching activity is to add a new data in the file, in this case Mood.
        /// I have edited or changed some things to add mood in all the functions where it should be.
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Please, select an option:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            
            Console.WriteLine("What would you like to do?: ");
            string optionSelected = Console.ReadLine();
            int option = int.Parse(optionSelected);

            switch (option)
            {
                case 1:
                    journal.AddEntry();
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    journal.LoadJournal();
                    break;
                case 4:
                    journal.SaveJournal();
                    break;
                default:
                    Console.WriteLine("OK, see you next time!");
                    return;
            }

            Console.WriteLine(" ");
        }

    }
}