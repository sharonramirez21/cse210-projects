public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++; // we add +1
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} [{_amountCompleted}/{_target} completed!] (Bonus: {_bonus} points.)";
    }

    public override string GetStringRepresentations()
    {
        return $"Checklist, {_shortName}, {_description}, {_points}, {_target}, {_bonus}, {_amountCompleted}";
    }
}