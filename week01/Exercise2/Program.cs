using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();

        int percent = int.Parse(answer);

        string letter;

        // Determine the letter grade
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the + or -
        string sign = "";

        int lastDigit = percent % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        // A cannot have a +
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // F cannot have a + or -
        if (letter == "F")
        {
            sign = "";
        }

        // Display the grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine if the student passed
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Keep working hard. You can do better next time!");
        }
    }
}