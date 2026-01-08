using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            if (num == 0)
            {
                break;
            }
            numbers.Add(num);
        }

        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = (double)sum / numbers.Count;
            int largest = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largest}");

            // Stretch: smallest positive
            var positives = numbers.Where(n => n > 0);
            if (positives.Any())
            {
                int smallestPositive = positives.Min();
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Stretch: sorted list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers entered.");
        }
    }
}