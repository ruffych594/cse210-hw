// Created by: Rufaro Chirume

// The Entry class represents ONE journal entry in the Journal Project.
// Each entry remembers three things: the date it was written, the prompt
// the program asked, and my response to that prompt.

using System;

class Entry
{
    // Field: the date the entry was written
    public string _date;

    // Field: the prompt that was shown to me for this entry
    public string _prompt;

    // Field: what I typed in response to the prompt
    public string _response;

    // Constructor
    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    // Displays the entry
    public void DisplayEntry()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine(_response);
    }

    // Getter for date
    public string GetDate()
    {
        return _date;
    }

    // Getter for prompt
    public string GetPrompt()
    {
        return _prompt;
    }

    // Getter for response
    public string GetResponse()
    {
        return _response;
    }
}





