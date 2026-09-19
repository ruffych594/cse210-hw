// The Journal class holds a list of Entry objects and knows how to
// add, display, save, and load them.

using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    // The list that stores every entry in the journal.
    // It starts out empty.
    private List<Entry> _entries = new List<Entry>();

    // Adds a new entry to the end of the journal.
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Shows every entry on the screen, with a blank line between each one.
    public void DisplayEntries()
    {
        // Let the user know if there is nothing to show yet.
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
            Console.WriteLine();
        }
    }

    // Saves the whole journal to a text file.
    // Each entry becomes one line: date|prompt|response
    // I used the "|" symbol to separate the parts because it's rare in normal writing.
    public void SaveToFile(string filename)
    {
        // "using" makes sure the file gets closed properly when we're done.
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry.GetDate()}|{entry.GetPrompt()}|{entry.GetResponse()}");
            }
        }
    }

    // Loads entries from a file that was saved with SaveToFile.
    // This replaces whatever entries are currently in the journal.
    public void LoadFromFile(string filename)
    {
        // Start fresh so we don't end up with duplicate entries.
        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            // Split the line into at most 3 pieces: date, prompt, response.
            // Limiting it to 3 means that if my response itself contains a "|",
            // the extra "|" stays part of the response instead of breaking it apart.
            string[] parts = line.Split('|', 3);

            // Skip any line that doesn't have all 3 parts (blank or damaged lines).
            if (parts.Length < 3)
            {
                continue;
            }

            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];

            // Rebuild the Entry and put it back in the journal.
            Entry entry = new Entry(date, prompt, response);
            _entries.Add(entry);
        }
    }
}
