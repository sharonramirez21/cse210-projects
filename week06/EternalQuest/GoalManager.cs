public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

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
        string points = Console.ReadLine();

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
        Console.Write("Enter the number of the goal: ");
        int index = int.Parse(Console.ReadLine()) - 1; 

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += 10;
            Console.WriteLine("Event recorded!");
        }
        else
        {
            Console.WriteLine("Invalid goal number. Please select a valid goal from the list.");
        }
    }

    public void SaveGoals()
    {
        Console.WriteLine("Enter the filename to save (default: goals.txt): ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "goals.txt"; 
        }

        try
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to save.");
                return;
            }

            using (StreamWriter outputFile = new StreamWriter(filename, false))
            {
                outputFile.WriteLine(_score);

                foreach (var goal in _goals)
                {
                    string goalRepresentation = goal.GetStringRepresentations();
                    Console.WriteLine($"Saving goal: {goalRepresentation}");
                    outputFile.WriteLine(goalRepresentation);
                }
            }
            Console.WriteLine($"Goals saved successfully in {filename}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.WriteLine("Enter the filename to load (default: goals.txt): ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "goals.txt";
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine($"Error: The file '{filename}' does not exist.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0].Trim()); 
            _goals.Clear(); 

            foreach (string line in lines.Skip(1))
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 4)
                {
                    string type = parts[0].Trim();
                    string name = parts[1].Trim();
                    string description = parts[2].Trim();
                    string points = parts[3].Trim();

                    if (type == "Simple")
                    {
                        bool isComplete = parts.Length > 4 && bool.Parse(parts[4].Trim());
                        SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                        if (isComplete) simpleGoal.RecordEvent();
                        _goals.Add(simpleGoal);
                    }
                    else if (type == "Eternal")
                    {
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (type == "Checklist" && parts.Length >= 7)
                    {
                        int target = int.Parse(parts[4].Trim());
                        int bonus = int.Parse(parts[5].Trim());
                        int amountCompleted = int.Parse(parts[6].Trim());

                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                        
                        for (int i = 0; i < amountCompleted; i++)
                        {
                            checklistGoal.RecordEvent();
                        }

                        _goals.Add(checklistGoal);
                    }
                    else
                    {
                        Console.WriteLine($"Error: Incomplete data or unrecognized type on the line: {line}");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: Incomplete data on the line: {line}");
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading from file: {ex.Message}");
        }
    }


    // Progress report
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
}
