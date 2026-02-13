using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new RunningActivity(new DateTime(2022, 11, 03), 30, 3.0),
            new CyclingActivity(new DateTime(2022, 11, 03), 45, 12.0),
            new SwimmingActivity(new DateTime(2022, 11, 03), 40, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}