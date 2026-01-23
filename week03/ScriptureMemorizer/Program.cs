using System;

class Program
{
    // Scripture Memorizer - hides words in scripture to help people practice
    // hiding 3 words at a time so they can test themselves
    static void Main(string[] args)
    {
        // make a reference for John 3:16
        Reference johnRef = new Reference("John", 3, 16);
        
        // create the scripture with the text
        Scripture scripture = new Scripture(johnRef, 
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        
        // keep going until they quit or all words are hidden
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            
            // if all words hidden, we're done
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nYou've hidden all the words! Good job!");
                break;
            }
            
            Console.Write("Press enter or type 'quit': ");
            string userInput = Console.ReadLine();
            
            if (userInput.ToLower() == "quit")
            {
                Console.WriteLine("See you next time!");
                break;
            }
            
            // hide 3 more words
            scripture.HideRandomWords(3);
        }
    }
}
