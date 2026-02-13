using System;

class RunningActivity : Activity
{
    private double _distanceMiles;

    public RunningActivity(DateTime date, int minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60.0;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }

    protected override string GetActivityName()
    {
        return "Running";
    }
}
