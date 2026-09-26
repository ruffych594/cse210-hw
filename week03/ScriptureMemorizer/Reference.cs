// Stores where a scripture comes from, such as "Proverbs 3:5-6"
public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Use this one for a single verse, like John 3:16
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;

        // With only one verse, the start and end are the same
        _startVerse = verse;
        _endVerse = verse;
    }

    // Use this one for a range of verses, like Proverbs 3:5-6
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Turns the reference into readable text
    public string GetDisplayText()
    {
        // Single verse: "John 3:16"
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        // Verse range: "Proverbs 3:5-6"
        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}
