using System;

/*
    BEYOND CORE REQUIREMENTS:
    This implementation uses the pipe (|) character as a separator for saving/loading entries,
    which is unlikely to appear in normal journal content. The program provides a clean menu
    interface for easy navigation and uses proper object-oriented design with abstraction
    principles throughout.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Journal Menu Options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    DisplayJournal(journal);
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry entry = new Entry(prompt, response, date);
        journal.AddEntry(entry);

        Console.WriteLine("Entry added successfully.\n");
    }

    static void DisplayJournal(Journal journal)
    {
        Console.WriteLine("=== Journal Entries ===");
        journal.DisplayAll();
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}