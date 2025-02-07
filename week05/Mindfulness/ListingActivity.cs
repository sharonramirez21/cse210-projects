class ListingActivity : Activity
{
    private int _count;
    private List<string> _promts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the goods things in your life by having you list as many things as you can in a certain era") {}

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPromt();
        Console.WriteLine(prompt);

        ShowCountDown(5);

        // end time
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> userResponses = new List<string>();

        Console.WriteLine("Start listing (to end type 'finish')");

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && input.ToLower() == "finish") break;
            if (!string.IsNullOrWhiteSpace(input)) userResponses.Add(input);
        }

        _count = userResponses.Count;
        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }

    private string GetRandomPromt()
    {
        Random random = new Random();
        return _promts[random.Next(_promts.Count)];
    }
}