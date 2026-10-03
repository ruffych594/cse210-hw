using System;

// ----- Ways I went beyond the core requirements -----
// 1. No repeated prompts or questions: the PromptPicker class makes sure every
//    prompt/question is used once before any of them can come up again.
// 2. Activity log: ActivityLog keeps track of how many times each activity was
//    done and for how many seconds in total. It is saved to "activity_log.txt"
//    and loaded again when the program starts, so the history is remembered.
//    You can see it with option 4 in the menu.
// 3. Extra input checking: if someone types a letter or a negative number for
//    the duration, the program asks again instead of crashing.
// ----------------------------------------------------

class Program
{
    static void Main(string[] args)
    {
        // Load any history from earlier sessions
        ActivityLog log = new ActivityLog("activity_log.txt");
        log.Load();

        bool keepGoing = true;

        while (keepGoing)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View my log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            if (choice == "1")
            {
                activity = new BreathingActivity();
            }
            else if (choice == "2")
            {
                activity = new ReflectionActivity();
            }
            else if (choice == "3")
            {
                activity = new ListingActivity();
            }
            else if (choice == "4")
            {
                log.DisplaySummary();
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu.");
                Console.ReadLine();
            }
            else if (choice == "5")
            {
                keepGoing = false;
            }
            else
            {
                Console.WriteLine("That isn't one of the options. Press enter to try again.");
                Console.ReadLine();
            }

            // If the user picked an activity, run it and then record it
            if (activity != null)
            {
                activity.Run();
                log.AddEntry(activity.GetName(), activity.GetDuration());
            }
        }

        Console.Clear();
        Console.WriteLine("Thanks for taking some time for yourself. Goodbye!");
    }
}
