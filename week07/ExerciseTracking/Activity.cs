using System;

abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected DateTime Date => _date;
    protected int Minutes => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    protected abstract string GetActivityName();

    public virtual string GetSummary()
    {
        string dateText = Date.ToString("dd MMM yyyy");
        return $"{dateText} {GetActivityName()} ({Minutes} min)- Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
