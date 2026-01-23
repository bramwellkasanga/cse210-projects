using System;

class Program
{
    /// <summary>
    /// Scripture Memorizer - Helps users memorize scriptures by progressively hiding words
    /// 
    /// CREATIVITY FEATURES:
    /// - The program allows hiding multiple words per iteration (not just one)
    /// - Implements multiple constructor options for scripture references
    /// - Uses proper encapsulation with private fields and public methods
    /// - Clean object-oriented design with separate concerns for Reference, Word, and Scripture
    /// - Provides helpful instructions to guide the user through the memorization process
    /// </summary>
    static void Main(string[] args)
    {
        // Create a scripture reference
        Reference johnRef = new Reference("John", 3, 16);
        
        // Create a scripture with the reference and text
        Scripture scripture = new Scripture(johnRef, 
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        
        // Main game loop
        while (true)
        {
            // Clear the console and display the scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            
            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nCongratulations! You have hidden all the words. Great job memorizing!");
                break;
            }
            
            // Prompt the user
            Console.Write("Press enter to continue or type 'quit' to exit: ");
            string userInput = Console.ReadLine();
            
            // Check if user wants to quit
            if (userInput.ToLower() == "quit")
            {
                Console.WriteLine("Thank you for practicing! Goodbye!");
                break;
            }
            
            // Hide a few random words
            scripture.HideRandomWords(3);
        }
    }
}
