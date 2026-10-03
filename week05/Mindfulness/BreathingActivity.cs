using System;

// The BreathingActivity walks the user through slow breathing in and out.
public class BreathingActivity : Activity
{
    // How many seconds each part of a breath lasts
    private int _breatheInSeconds = 4;
    private int _breatheOutSeconds = 6;

    // Sends the name and description up to the base class
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void RunActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // Keep alternating between in and out until the time is up
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountDown(_breatheInSeconds);
            Console.WriteLine();

            // Don't start a breath out if there's no time left
            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Now breathe out... ");
            ShowCountDown(_breatheOutSeconds);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
