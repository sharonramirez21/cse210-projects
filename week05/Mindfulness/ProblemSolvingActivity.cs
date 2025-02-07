class ProblemSolvingActivity : Activity
{
    private List<string> _questions = new List<string>
    {
        "What is the problem you want to solve?",
        "What options do you have to solve it?",
        "What are the first steps you can take to solve it?",
        "Imagine that the problem is already solved. What did you do to achieve it?"
    };

    public ProblemSolvingActivity() : base ("Problem-Solving", "This activity helps you analyze a problem and explore solutions in a structured way"){}

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Think about a problem that is currently on your mind.");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            foreach (var question in _questions)
            {
                Console.WriteLine(question);
                if (DateTime.Now >= endTime) break;
                Console.Write("Your answer: ");
                Console.ReadLine();
            }
        }
        Console.WriteLine("Take a moment to reflect on your answers. Have you found a solution?");
        DisplayEndingMessage();
    }
}