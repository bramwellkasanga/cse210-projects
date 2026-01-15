using System;

public class Entry
{
    // Member variables
    private string _prompt;
    private string _response;
    private string _date;

    // Constructor
    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    // Methods
    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetResponse()
    {
        return _response;
    }

    public string GetDate()
    {
        return _date;
    }

    // Display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    // Convert entry to string format for saving
    public string GetStringFormat()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    // Create entry from string format (for loading)
    public static Entry CreateFromString(string line)
    {
        string[] parts = line.Split("|");
        if (parts.Length == 3)
        {
            return new Entry(parts[1], parts[2], parts[0]);
        }
        return null;
    }
}
