public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Goal: {_shortName} recorded!. You earned: {_points} points");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentations()
    {
        return $"Eternal, {_shortName}, {_description}, {_points}";
    }
}