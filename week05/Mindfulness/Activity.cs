class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = GetDurationFromUser();
    }

    // starting message :)
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity!");
        Console.WriteLine(_description);
        Console.WriteLine($"Duration of the activity: {_duration}");
        ShowSpinner(3);
    }

    // We ask the user for a duration
    public int GetDurationFromUser()
    {
        Console.WriteLine("give a time in seconds: ");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number: ");
        }
        return duration;
    }


    // ending message
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Nice job!! You completed the {_name} activity.");
    }    

    // animated spinner
    public void ShowSpinner(int seconds)
    {
        Console.WriteLine("Get ready!");
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write($"\r{spinner[i % 4]} ");
            Thread.Sleep(250);
        }
        Console.Write("\r  \r");
    }


    // countdown
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}... "); // --- We show the countdown
            Thread.Sleep(1000); // for one second
        }
        Console.Write("\r   \r");
    }
}