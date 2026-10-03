using System;
using System.Threading;

// Activity is the base class for every mindfulness activity.
// Anything the activities have in common (name, description, duration, the
// starting and ending messages, and the spinner/countdown animations) lives
// here so we don't have to repeat it in each derived class.
public abstract class Activity
{
    private string _name;
    private string _description;

    // Protected so the derived classes can use the duration directly
    // when they work out how long to keep going.
    protected int _duration;

    // Constructor: each derived class passes in its own name and description
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    // This is the one method Program.cs calls. It runs the same steps
    // for every activity: start message, the activity itself, ending message.
    public void Run()
    {
        DisplayStartingMessage();
        RunActivity();
        DisplayEndingMessage();
    }

    // Each derived class has to write its own version of this method,
    // because this is the part that is different for every activity.
    protected abstract void RunActivity();

    // Common starting message shared by all activities
    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = AskForDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        Console.WriteLine();
    }

    // Common ending message shared by all activities
    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);
    }

    // Keeps asking until the user types a whole number bigger than zero.
    // (Without this the program would crash if someone typed a letter.)
    private int AskForDuration()
    {
        int seconds = 0;

        while (seconds <= 0)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out seconds) || seconds <= 0)
            {
                Console.WriteLine("Please enter a whole number greater than 0.");
                seconds = 0;
            }
        }

        return seconds;
    }

    // Shows a little spinning line for the given number of seconds.
    // It uses backspaces to erase the old character before drawing the next one.
    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameNumber = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[frameNumber]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            frameNumber = (frameNumber + 1) % frames.Length;
        }
    }

    // Counts down from the given number, replacing each number with backspaces
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string number = i.ToString();

            Console.Write(number);
            Thread.Sleep(1000);

            // One "\b \b" for every digit so two-digit numbers get erased too
            for (int j = 0; j < number.Length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }
}
