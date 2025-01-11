using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Write a series of numbers (enter 0 to stop)");

        do
        {
            Console.WriteLine("Enter a number: ");
            string UserNumber = Console.ReadLine();

            if (int.TryParse(UserNumber, out number))
            {
                if (number != 0)
                {
                    numbers.Add(number);
                }
            }
        } while (number != 0);

        // #1 step
        int sum = 0; 
        foreach (int num in numbers)
        {
            sum += num;
        }

        Console.WriteLine($"The sum is: {sum}");


        // #2 Step
        double average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // #3 step
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine($"The largest number in the list is: {max}");
    }
}