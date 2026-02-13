using System;

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _completedCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int bonus, int targetCount, int completedCount = 0)
        : base(name, description, points)
    {
        _bonus = bonus;
        _targetCount = targetCount;
        _completedCount = completedCount;
    }

    public override int RecordEvent()
    {
        if (_completedCount >= _targetCount)
        {
            return 0;
        }

        _completedCount++;

        if (_completedCount >= _targetCount)
        {
            return Points + _bonus;
        }

        return Points;
    }

    public override bool IsComplete()
    {
        return _completedCount >= _targetCount;
    }

    public override string GetDetailsString()
    {
        string details = base.GetDetailsString();
        return $"{details} -- Completed {_completedCount}/{_targetCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetBaseSaveString()}|{_bonus}|{_targetCount}|{_completedCount}";
    }
}
