public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false;
    }


    // we call the overrise to chage the action in the method
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Goal: {_shortName} completed!. You earned: {_points} points");
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentations()
    {
        return $"Simple, {_shortName}, {_description}, {_points}, {_isComplete}";
    }
}