using System;

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // hides the word
    public void Hide()
    {
        _isHidden = true;
    }

    // returns the word or underscores if hidden
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }

    // checks if the word is already hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // gets the actual word
    public string GetText()
    {
        return _text;
    }
}
