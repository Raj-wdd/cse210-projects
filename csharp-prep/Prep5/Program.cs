using System;

class Program
{
    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt for a name
    static string GetName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt for a favorite number
    static int GetNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to square the number
    static int Square(int number)
    {
        return number * number;
    }

    // Main function
    static void Main()
    {
        DisplayWelcome();  // Display welcome message
        string name = GetName();  // Get user name
        int number = GetNumber();  // Get favorite number
        int squared = Square(number);  // Square the number

        Console.WriteLine($"{name}, the square of your number is {squared}");
    }
}
