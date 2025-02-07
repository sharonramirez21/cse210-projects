using System.Diagnostics;
class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string> 
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    
    private List<string> _questions = new List<string> 
    { 
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when your have shown strength and recilience.") {}

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Starting Reflecting Activity...\n");

        string prompt = GetRandomPromt();
        Console.WriteLine($"{prompt}");
        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        Console.WriteLine($"Activity will run for {_duration} seconds...\n");

        List<string> remainingQuestions = new List<string>(_questions);
        while (DateTime.Now < endTime && remainingQuestions.Count > 0)
        {
            string question = GetRandomQuestion(remainingQuestions);
            Console.WriteLine($"{question}");
            ShowCountDown(5);
        }

        Console.WriteLine("Activity completed!");
        DisplayEndingMessage();
    }

    private string GetRandomPromt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion(List<string> remainingQuestions)
    {
        Random random = new Random();
        int index = random.Next(remainingQuestions.Count);
        string question = remainingQuestions[index];
        remainingQuestions.RemoveAt(index); // again? no!
        return question;
    }
}