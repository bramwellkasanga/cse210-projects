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
        
        // split the text by spaces and make Word objects for each
        string[] textArray = text.Split(' ');
        foreach (string word in textArray)
        {
            _words.Add(new Word(word));
        }
    }

    // returns the full scripture with reference and all the words
    public string GetDisplayText()
    {
        string result = _reference.GetReference() + " ";
        
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        
        return result.Trim();
    }

    // hides some random words (picks them at random)
    public void HideRandomWords(int numberToHide = 1)
    {
        Random random = new Random();
        
        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = random.Next(_words.Count);
            _words[randomIndex].Hide();
        }
    }

    // checks if all words are hidden
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
