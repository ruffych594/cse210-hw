using System;
using System.Collections.Generic;

// The ListingActivity gives the user a prompt and lets them list as many
// answers as they can before the time is up.
public class ListingActivity : Activity
{
    private PromptPicker _promptPicker;

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _promptPicker = new PromptPicker(new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        });
    }

    protected override void RunActivity()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {_promptPicker.GetNext()} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> items = GetListFromUser();

        Console.WriteLine($"You listed {items.Count} items!");
    }

    // Collects what the user types until the duration has passed
    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.Write("> ");

        while (DateTime.Now < endTime)
        {
            // Only read a line once the user has started typing, so the
            // loop can still notice when the time is up while they wait.
            if (Console.KeyAvailable)
            {
                string item = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }

                Console.Write("> ");
            }
            else
            {
                System.Threading.Thread.Sleep(50);
            }
        }

        Console.WriteLine();
        return items;
    }
}
