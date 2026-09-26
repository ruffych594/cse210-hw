using System;
using System.Collections.Generic;

// Represents a whole scripture: its reference plus all of its words.
// This class is in charge of hiding words and building the text to display.
public class Scripture
{
    // How many words get hidden each time the user presses Enter
    private const int WordsToHideEachRound = 3;

    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Break the text into individual words, ignoring any accidental extra spaces
        string[] splitWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Wrap each piece of text in a Word object so it can be hidden later
        foreach (string splitWord in splitWords)
        {
            _words.Add(new Word(splitWord));
        }
    }

    // Hides a few random words that are still visible
    public void HideRandomWords()
    {
        int wordsHidden = 0;

        while (wordsHidden < WordsToHideEachRound)
        {
            // Pick a random spot in the list of words
            int index = _random.Next(_words.Count);

            // Only count it if the word wasn't already hidden,
            // otherwise we might "hide" the same word twice
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                wordsHidden++;
            }

            // If there's nothing left to hide, stop so we don't loop forever
            if (IsCompletelyHidden())
            {
                break;
            }
        }
    }

    // Returns true only when every word has been hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            // Finding even one visible word means we're not done yet
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    // Builds the text shown to the user, e.g. "Proverbs 3:5-6 Trust in the ____ ..."
    public string GetDisplayText()
    {
        string text = "";

        // Add each word (or its underscores, if hidden) followed by a space
        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }

        // Put the reference in front of the scripture text
        return $"{_reference.GetDisplayText()} {text}";
    }
}
