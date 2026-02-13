using System;

class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000.0 * 0.62;
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
        return "Swimming";
    }
}
