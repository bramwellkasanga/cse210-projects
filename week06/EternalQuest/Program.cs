using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Creativity: added a simple level system that announces level-ups based on score thresholds.
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;
        int levelIndex = GetLevelIndex(score);

        while (true)
        {
            Console.WriteLine($"\nYou have {score} points. Level: {GetLevelName(levelIndex)}");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            int choice = PromptInt("Select a choice from the menu: ");

            switch (choice)
            {
                case 1:
                    CreateGoal(goals);
                    break;
                case 2:
                    ListGoals(goals);
                    break;
                case 3:
                    SaveGoals(goals, score);
                    break;
                case 4:
                    LoadGoals(goals, ref score);
                    levelIndex = GetLevelIndex(score);
                    break;
                case 5:
                    RecordEvent(goals, ref score, ref levelIndex);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int choice = PromptInt("Which type of goal would you like to create? ");
        string name = PromptString("What is the name of your goal? ");
        string description = PromptString("What is a short description of it? ");
        int points = PromptInt("What is the amount of points associated with this goal? ");

        switch (choice)
        {
            case 1:
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                int target = PromptInt("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = PromptInt("What is the bonus for accomplishing it that many times? ");
                goals.Add(new ChecklistGoal(name, description, points, bonus, target));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void ListGoals(List<Goal> goals)
    {
        Console.WriteLine("\nYour goals are:");

        if (goals.Count == 0)
        {
            Console.WriteLine("  (No goals yet)");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void SaveGoals(List<Goal> goals, int score)
    {
        string filename = PromptString("What is the filename for the goal file? ");

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{score}");

            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals(List<Goal> goals, ref int score)
    {
        string filename = PromptString("What is the filename for the goal file? ");

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 0)
            {
                continue;
            }

            if (parts[0] == "Score" && parts.Length > 1)
            {
                score = int.Parse(parts[1]);
                continue;
            }

            Goal goal = CreateGoalFromParts(parts);

            if (goal != null)
            {
                goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    static void RecordEvent(List<Goal> goals, ref int score, ref int levelIndex)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record yet.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {goals[i].GetDetailsString()}");
        }

        int choice = PromptInt("Enter the number of the goal: ");

        if (choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal goal = goals[choice - 1];
        int earnedPoints = goal.RecordEvent();

        if (earnedPoints == 0)
        {
            Console.WriteLine("That goal is already complete.");
            return;
        }

        score += earnedPoints;
        Console.WriteLine($"You earned {earnedPoints} points!");

        int newLevelIndex = GetLevelIndex(score);

        if (newLevelIndex > levelIndex)
        {
            levelIndex = newLevelIndex;
            Console.WriteLine($"Level up! You are now {GetLevelName(levelIndex)}.");
        }
    }

    static Goal CreateGoalFromParts(string[] parts)
    {
        string type = parts[0];

        if (type == "SimpleGoal" && parts.Length >= 5)
        {
            return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
        }

        if (type == "EternalGoal" && parts.Length >= 4)
        {
            return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
        }

        if (type == "ChecklistGoal" && parts.Length >= 7)
        {
            return new ChecklistGoal(
                parts[1],
                parts[2],
                int.Parse(parts[3]),
                int.Parse(parts[4]),
                int.Parse(parts[5]),
                int.Parse(parts[6])
            );
        }

        return null;
    }

    static int PromptInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid number.");
        }
    }

    static string PromptString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    static int GetLevelIndex(int score)
    {
        int[] thresholds = new int[] { 0, 1000, 2500, 5000 };
        int index = 0;

        for (int i = 0; i < thresholds.Length; i++)
        {
            if (score >= thresholds[i])
            {
                index = i;
            }
        }

        return index;
    }

    static string GetLevelName(int levelIndex)
    {
        string[] levels = new string[] { "Novice", "Seeker", "Disciple", "Master" };

        if (levelIndex < 0)
        {
            return levels[0];
        }

        if (levelIndex >= levels.Length)
        {
            return levels[levels.Length - 1];
        }

        return levels[levelIndex];
    }
}