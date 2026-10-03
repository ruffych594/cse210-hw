using System;
using System.Collections.Generic;

// PromptPicker hands out random prompts or questions, but it never repeats
// one until every item in the list has been used once. After that it starts over.
public class PromptPicker
{
    private List<string> _allItems;
    private List<string> _unusedItems;
    private Random _random = new Random();

    public PromptPicker(List<string> items)
    {
        _allItems = items;
        _unusedItems = new List<string>(items);
    }

    // Returns a random item that hasn't been used yet
    public string GetNext()
    {
        // If we've used everything, refill the unused list and start again
        if (_unusedItems.Count == 0)
        {
            _unusedItems = new List<string>(_allItems);
        }

        int index = _random.Next(_unusedItems.Count);
        string chosen = _unusedItems[index];
        _unusedItems.RemoveAt(index);

        return chosen;
    }
}
