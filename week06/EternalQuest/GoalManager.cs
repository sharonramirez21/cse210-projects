using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    protected int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public string DisplayPlayInfo()
    {
        return $"Actual points: {_score}";
    }

    public void Start()
    {
        Console.WriteLine("Start");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("List of names");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select the type of goal");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. CheckList");

        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Name of the goal: ");
        string name = Console.ReadLine();
        Console.WriteLine("Description: ");
        string description = Console.ReadLine();
        Console.WriteLine("Points: ");
        string points = Console.ReadLine();  // Cambio a int en vez de string

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.WriteLine("Objective (times to complete): ");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Bonus on completion: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid option");
                return;
        }
        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select the goal number to record an event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}"); 
        }

        Console.Write("Enter the number of the goal: ");
        int index = int.Parse(Console.ReadLine()) - 1; 

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent(ref _score);
            Console.WriteLine("Event recorded!");
        }
        else
        {
            Console.WriteLine("Invalid goal number. Please select a valid goal from the list.");
        }
    }


    public void SaveGoals()
    {
        Console.WriteLine("Enter the filename to save (e.g., 'goals.txt'): ");
        string filename = Console.ReadLine();
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename); // i added this because dont let me create the file here 

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filePath, false)) 
            {
                outputFile.WriteLine(_score); 

                foreach (var goal in _goals)
                {
                    string goalType = goal.GetType().Name;
                    outputFile.WriteLine($"{goal.GetStringRepresentations()}"); 
                }
            }

            Console.WriteLine("Goals saved successfully to: " + filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }


   public void LoadGoals()
    {
        Console.WriteLine("Enter the filename to load (e.g., 'goals.txt'): ");
        string filename = Console.ReadLine();
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            _score = int.Parse(lines[0].Trim()); // first line: score
            _goals.Clear();
            foreach (string line in lines.Skip(1)) // not first line
            {
                string[] parts = line.Split(','); // split using ,

                if (parts.Length >= 4)
                {
                    string type = parts[0].Trim();
                    string name = parts[1].Trim();
                    string description = parts[2].Trim();
                    string points = parts[3].Trim();


                    if (type.Equals("Simple", StringComparison.OrdinalIgnoreCase))
                    {
                        _goals.Add(new SimpleGoal(name, description, points));
                    }
                    else if (type.Equals("Eternal", StringComparison.OrdinalIgnoreCase))
                    {
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (type.Equals("Checklist", StringComparison.OrdinalIgnoreCase) && parts.Length >= 6)
                    {
                        int target = int.Parse(parts[4].Trim());
                        int bonus = int.Parse(parts[5].Trim());
                        _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully!");
            Console.WriteLine("Loaded goals:");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading from file: {ex.Message}");
        }
    }



    // i added the method for ShowProgress
    public void ShowProgressReport()
    {
        int total = _goals.Count;
        int completedGoals = _goals.Count(g => g.IsComplete());

        Console.WriteLine("=== Progress Report ===");
        Console.WriteLine($"Total goals: {total}");
        Console.WriteLine($"Completed goals: {completedGoals}");
        Console.WriteLine($"Pending goals: {total - completedGoals}");

        if (total > 0)
        {
            double completionRate = (double)completedGoals / total * 100;
            Console.WriteLine($"Total Progress: {completionRate:F2}%");
        }
        else
        {
            Console.WriteLine("There are no goals recorded!");
        }
    }

    // to clear all the file (empty)
    public void ClearAllGoals()
    {
        Console.WriteLine("Enter the filename to clear (e.g., 'goals.txt'): ");
        string filename = Console.ReadLine();
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);

        Console.WriteLine("Are you sure you want to clear all goals? This will delete all data from the file (y/n): ");
        string confirmation = Console.ReadLine().ToLower();

        if (confirmation == "y")
        {
            try
            {
                File.WriteAllText(filePath, string.Empty);
                _goals.Clear(); 
                _score = 0;
                Console.WriteLine("All goals have been cleared and the file is empty.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing the file: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Action canceled. The file was not cleared.");
        }
    }

}
