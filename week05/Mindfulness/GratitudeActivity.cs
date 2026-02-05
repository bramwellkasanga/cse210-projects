using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private readonly List<string> _prompts = new List<string>
    {
        "Recall a small win from today.",
        "Think of a person who made your day better.",
        "Remember a moment of peace you felt recently.",
        "Think of something in nature that you appreciate.",
        "Recall a skill or ability you are grateful for."
    };

    public GratitudeActivity()
        : base(
            "Gratitude Activity",
            "This activity will help you focus on gratitude by briefly noting moments, people, and gifts in your life.")
    {
    }

    public void Run()
    {
        StartActivity();

        Random random = new Random();
        Queue<string> promptQueue = CreateShuffledQueue(_prompts, random);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            if (promptQueue.Count == 0)
            {
                promptQueue = CreateShuffledQueue(_prompts, random);
            }

            Console.WriteLine($"Prompt: {promptQueue.Dequeue()}");
            Console.Write("> ");
            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item.Trim());
            }

            Console.WriteLine("Take a slow breath...");
            ShowSpinner(2);
            Console.WriteLine();
        }

        Console.WriteLine($"You recorded {items.Count} gratitude notes.");

        EndActivity();
    }
}
