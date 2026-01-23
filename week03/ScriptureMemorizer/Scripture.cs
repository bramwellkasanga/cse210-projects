using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Split the scripture text into words and create Word objects
        string[] textArray = text.Split(' ');
        foreach (string word in textArray)
        {
            _words.Add(new Word(word));
        }
    }

    /// <summary>
    /// Returns the formatted scripture with reference and text
    /// </summary>
    public string GetDisplayText()
    {
        string result = _reference.GetReference() + " ";
        
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        
        return result.Trim();
    }

    /// <summary>
    /// Hides a random word from the scripture
    /// </summary>
    public void HideRandomWords(int numberToHide = 1)
    {
        Random random = new Random();
        
        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = random.Next(_words.Count);
            _words[randomIndex].Hide();
        }
    }

    /// <summary>
    /// Checks if all words in the scripture are hidden
    /// </summary>
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
