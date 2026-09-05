using System;

class Program
{
    static void Main(string[] args)
    {
        // This is a code that asks the user for their name.
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine(); // This line reads the user's input and stores it in the variable 'firstName'.

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine(); // This line reads the user's input and stores it in the variable 'lastName'.

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}."); // This line outputs a greeting message that includes the user's full name.
    }
}