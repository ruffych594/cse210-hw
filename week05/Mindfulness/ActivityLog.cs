using System;
using System.Collections.Generic;
using System.IO;

// ActivityLog remembers every activity the user has done, and saves the
// history to a text file so it is still there the next time the program runs.
public class ActivityLog
{
    private string _filePath;
    private List<string> _activityNames = new List<string>();
    private List<int> _activitySeconds = new List<int>();

    public ActivityLog(string filePath)
    {
        _filePath = filePath;
    }

    // Adds a finished activity to the log and saves it right away
    public void AddEntry(string activityName, int seconds)
    {
        _activityNames.Add(activityName);
        _activitySeconds.Add(seconds);
        Save();
    }

    // Writes one line per entry in the form: name|seconds
    private void Save()
    {
        List<string> lines = new List<string>();

        for (int i = 0; i < _activityNames.Count; i++)
        {
            lines.Add($"{_activityNames[i]}|{_activitySeconds[i]}");
        }

        File.WriteAllLines(_filePath, lines);
    }

    // Reads the old entries from the file, if there is one
    public void Load()
    {
        if (!File.Exists(_filePath))
        {
            return;
        }

        foreach (string line in File.ReadAllLines(_filePath))
        {
            string[] parts = line.Split('|');

            if (parts.Length == 2 && int.TryParse(parts[1], out int seconds))
            {
                _activityNames.Add(parts[0]);
                _activitySeconds.Add(seconds);
            }
        }
    }

    // Prints how many times each activity was done and the total time spent
    public void DisplaySummary()
    {
        Console.Clear();
        Console.WriteLine("Your mindfulness log");
        Console.WriteLine("--------------------");

        if (_activityNames.Count == 0)
        {
            Console.WriteLine("Nothing here yet. Try an activity first!");
            return;
        }

        List<string> shownNames = new List<string>();

        foreach (string name in _activityNames)
        {
            if (shownNames.Contains(name))
            {
                continue;
            }

            shownNames.Add(name);

            int timesDone = 0;
            int totalSeconds = 0;

            for (int i = 0; i < _activityNames.Count; i++)
            {
                if (_activityNames[i] == name)
                {
                    timesDone++;
                    totalSeconds += _activitySeconds[i];
                }
            }

            Console.WriteLine($"{name}: {timesDone} time(s), {totalSeconds} seconds in total");
        }
    }
}
