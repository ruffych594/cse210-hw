using System;

// The Comment class represents one comment that a viewer leaves on a video.
// It only needs to remember who wrote it and what they said.
public class Comment
{
    // Member variables are private so other classes can't change them directly
    private string _name;
    private string _text;

    // Constructor: runs when we create a new Comment, and sets up its values
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // Returns the name of the person who wrote the comment
    public string GetName()
    {
        return _name;
    }

    // Returns the actual text of the comment
    public string GetText()
    {
        return _text;
    }
}
