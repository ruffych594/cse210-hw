using System;
using System.Collections.Generic;

// The Video class represents a YouTube video.
// It keeps track of the title, author, length, and all the comments left on it.
public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;

    // A video "has" many comments, so we store them in a list of Comment objects.
    // This is called composition: one class holding objects of another class.
    private List<Comment> _comments = new List<Comment>();

    // Constructor: sets up the basic details. Comments get added afterwards.
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
    }

    // Adds a new comment to this video's list
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Returns how many comments the video has.
    // We just ask the list for its Count, so the number is always up to date.
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Returns the title of the video
    public string GetTitle()
    {
        return _title;
    }

    // Returns the name of the video's creator
    public string GetAuthor()
    {
        return _author;
    }

    // Returns the length of the video in seconds
    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }

    // Returns the whole list of comments so they can be displayed
    public List<Comment> GetComments()
    {
        return _comments;
    }
}
