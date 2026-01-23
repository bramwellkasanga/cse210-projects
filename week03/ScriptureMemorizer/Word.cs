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

    /// <summary>
    /// Hides the word by replacing it with underscores
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Returns the word if visible, or underscores if hidden
    /// </summary>
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }

    /// <summary>
    /// Checks if this word is already hidden
    /// </summary>
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Gets the actual text of the word
    /// </summary>
    public string GetText()
    {
        return _text;
    }
}
