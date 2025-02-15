public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false;
    }


    // we call the overrise to chage the action in the method
    public override void RecordEvent(ref int score)
    {
        _isComplete = true;
        score += int.Parse(_points);
        Console.WriteLine($"Goal: {_shortName} completed!. You earned: {_points} points");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentations()
    {
        return $"Simple, {_shortName}, {_description}, {_points}, {_isComplete}";
    }
}