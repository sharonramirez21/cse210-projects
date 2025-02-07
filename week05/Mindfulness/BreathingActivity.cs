class BreatingActivity : Activity
{
    public BreatingActivity() : base("Breathing","This Activity will help you relax by walking your through breathing in and out slowly.Clear your mind and focus on your breathing"){}

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(5);

            if (DateTime.Now >= endTime) break;

            Console.WriteLine("Now breathe out...");
            ShowCountDown(5);
        }

        DisplayEndingMessage();
    }
}