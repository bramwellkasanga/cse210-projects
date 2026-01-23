using System;

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    /// <summary>
    /// Constructor for a single verse reference (e.g., "John 3:16")
    /// </summary>
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    /// <summary>
    /// Constructor for a verse range reference (e.g., "Proverbs 3:5-6")
    /// </summary>
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    /// <summary>
    /// Returns the formatted reference as a string
    /// </summary>
    public string GetReference()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}
