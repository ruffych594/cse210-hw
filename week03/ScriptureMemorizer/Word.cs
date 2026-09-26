// Represents one word in the scripture, and whether it's currently hidden
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;

        // Every word starts out visible
        _isHidden = false;
    }

    // Marks the word as hidden
    public void Hide()
    {
        _isHidden = true;
    }

    // Lets other classes check whether this word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // What the user sees: the real word, or underscores if it's hidden
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // One underscore per letter, so the word's length is still a hint
            return new string('_', _text.Length);
        }

        return _text;
    }
}
