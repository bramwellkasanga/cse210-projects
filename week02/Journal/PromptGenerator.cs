using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // Member variables
    private List<string> _prompts;
    private Random _random;

    // Constructor
    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What accomplishment am I most proud of today?",
            "What lesson did I learn today?",
            "How did I help someone today?"
        };
    }

    // Methods
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
