using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please input your first name: ");
        string firstname = Console.ReadLine();
        Console.Write("Please inout your last name is: ");
        string lastname = Console.ReadLine();
        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}");
    }
}