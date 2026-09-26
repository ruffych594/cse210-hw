using System;

// Scripture Memorizer
// Shows a scripture on screen, then hides a few more words every time the
// user presses Enter. The goal is to help you memorize it bit by bit.
class Program
{
    static void Main(string[] args)
    {
        // Creativity: the scripture spans multiple verses (Proverbs 3:5-6),
        // and three random words disappear on each round instead of just one.

        // The reference tells us where the scripture comes from (book, chapter, verses)
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        // The full scripture text, with punctuation left out to keep things simple
        string text = "Trust in the Lord with all your heart and lean not on your own understanding In all your ways acknowledge him and he will make your paths straight";

        Scripture scripture = new Scripture(reference, text);

        // Keep going until every single word has been hidden
        while (!scripture.IsCompletelyHidden())
        {
            // Wipe the screen so only the latest version of the scripture shows
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");

            string input = Console.ReadLine();

            // If the user typed "quit" (in any capitalization), stop early.
            // The null check protects us if the input stream is closed.
            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            // Otherwise, hide the next few words and loop around
            scripture.HideRandomWords();
        }

        // Show the final state one last time (fully hidden, or wherever they quit)
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}
