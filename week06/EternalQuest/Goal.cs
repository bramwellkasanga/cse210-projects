using System;

abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    protected string Name => _name;
    protected string Description => _description;
    protected int Points => _points;

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {Name} ({Description})";
    }

    protected string GetBaseSaveString()
    {
        return $"{Name}|{Description}|{Points}";
    }

    public abstract string GetStringRepresentation();
}
