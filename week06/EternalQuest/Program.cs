using System;
using System.Drawing;
using System.IO;

// What I added was a progress report on the goals, adding the ShowProgressReport() in GoalManager
// and i added a method to clear all the file

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        manager.Start();

        while (true)
        { 
            Console.WriteLine($"You have {manager.DisplayPlayInfo()}");
            Console.WriteLine("");
            Console.WriteLine("\n--- Menu Options ---");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. View progress");
            Console.WriteLine("7. Clear file");
            Console.WriteLine("8. Quit..");
            Console.WriteLine("Select a choice from the menu: ");
        

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoalNames();
                    break;
                case "3":
                    manager.SaveGoals();
                    break;
                case "4":
                    manager.LoadGoals();
                    break;
                case "5":
                    manager.RecordEvent();
                    break;
                case "6":
                    manager.ShowProgressReport();
                    break;
                case "7":
                    manager.ClearAllGoals();
                    break;
                case "8":
                    Console.WriteLine("See you later!...");
                    return;
            }
        }
    }
}