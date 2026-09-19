// Journal Program
// A console app where the user can write journal entries based on random
// prompts, view them, and save/load them to a file.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // The journal that holds all of the entries for this session.
        Journal journal = new Journal();

        // The list of prompts the program picks from at random.
        string[] prompts =
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn today?",
            "What am I grateful for today?"
        };

        // Used to pick a random prompt each time.
        Random random = new Random();

        // Holds the menu option the user picks. 0 just means "nothing chosen yet".
        int choice = 0;

        // Keep showing the menu until the user chooses 5 (Quit).
        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            // TryParse is safer than Parse: if the user types letters instead of a
            // number, the program says so instead of crashing.
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
                choice = 0; // reset so the loop keeps going
                continue;
            }

            if (choice == 1)
            {
                // Option 1: write a new entry.
                // Pick a random prompt and show it to the user.
                string prompt = prompts[random.Next(prompts.Length)];

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                // Use today's date for the entry.
                string date = DateTime.Now.ToShortDateString();

                // Bundle everything into an Entry and add it to the journal.
                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                // Option 2: show all entries.
                journal.DisplayEntries();
            }
            else if (choice == 3)
            {
                // Option 3: save the journal to a file.
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);

                Console.WriteLine("Journal saved successfully.");
            }
            else if (choice == 4)
            {
                // Option 4: load the journal from a file.
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
 
                // Check the file exists first so a typo in the name doesn't crash the program.
                if (File.Exists(filename))
                {
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded successfully.");
                }
                else
                {
                    Console.WriteLine("Sorry, that file could not be found.");
                }
            }
            else if (choice == 5)
            {
                // Option 5: quit. The while loop ends after this.
                Console.WriteLine("Goodbye!");
            }
            else
            {
                // Any other number isn't on the menu.
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}

/*
Creativity / Exceeding Requirements:

I added an extra journal prompt to encourage more meaningful
reflection. I also added a confirmation message after saving
and loading the journal.
*/
