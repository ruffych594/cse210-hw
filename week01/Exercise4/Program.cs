using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the numbers
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Ask the user for numbers
        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            // Do not add 0 to the list
            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        // Calculate the sum
        int sum = 0;

        foreach (int item in numbers)
        {
            sum += item;
        }

        // Calculate the average
        double average = (double)sum / numbers.Count;

        // Find the largest number
        int largest = numbers[0];

        foreach (int item in numbers)
        {
            if (item > largest)
            {
                largest = item;
            }
        }

        // Find the smallest positive number
        int smallestPositive = int.MaxValue;

        foreach (int item in numbers)
        {
            if (item > 0 && item < smallestPositive)
            {
                smallestPositive = item;
            }
        }

        // Sort the list
        numbers.Sort();

        // Display the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers.");
        }

        Console.WriteLine("The sorted list is:");

        foreach (int item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}