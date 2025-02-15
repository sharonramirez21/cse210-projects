using System.ComponentModel.Design;
using System.Drawing;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent(ref int score);

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{_shortName}: {_description}, {_points}";
    }

    public virtual string GetStringRepresentations()
    {
        return $"{this.GetType().Name}, {_shortName}, {_description}, {_points}";
    }
}