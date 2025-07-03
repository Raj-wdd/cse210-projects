using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int score = 0;
        const string SaveFileName = "goals.txt";

        static readonly string[] MotivationalMessages = new string[]
        {
            "Great job! Keep going!",
            "Awesome work! You're crushing it!",
            "Keep it up! You're doing fantastic!",
            "Way to go! Keep pushing forward!",
            "You’re on fire! Keep that momentum!"
        };

        static Random rand = new Random();

        static void Main(string[] args)
        {
            LoadGoals();

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("\nEternal Quest - Main Menu");
                Console.WriteLine("1. Show Goals");
                Console.WriteLine("2. New Goal");
                Console.WriteLine("3. Record Completion");
                Console.WriteLine("4. Show Score");
                Console.WriteLine("5. Quit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowGoals();
                        break;
                    case "2":
                        CreateGoal();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        Console.WriteLine($"\nYour total score: {score}");
                        break;
                    case "5":
                        SaveGoals();
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ShowGoals()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            Console.WriteLine("\nYour Goals:");
            int i = 1;
            foreach (var goal in goals)
            {
                Console.WriteLine($"{i}. {goal.GetStatusString()} {goal.Name} - {goal.Description}");
                i++;
            }
        }

        static void CreateGoal()
        {
            Console.WriteLine("\nChoose Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string type = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter description: ");
            string desc = Console.ReadLine();

            Console.Write("Enter points per completion: ");
            if (!int.TryParse(Console.ReadLine(), out int pts))
            {
                Console.WriteLine("Invalid points.");
                return;
            }

            switch (type)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, desc, pts));
                    Console.WriteLine("Simple Goal added.");
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, desc, pts));
                    Console.WriteLine("Eternal Goal added.");
                    break;
                case "3":
                    Console.Write("Enter number of times to complete goal: ");
                    if (!int.TryParse(Console.ReadLine(), out int target))
                    {
                        Console.WriteLine("Invalid number.");
                        return;
                    }
                    Console.Write("Enter bonus points on completion: ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus))
                    {
                        Console.WriteLine("Invalid bonus.");
                        return;
                    }
                    goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
                    Console.WriteLine("Checklist Goal added.");
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        static void RecordEvent()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
                return;
            }

            Console.WriteLine("\nSelect goal to record event:");
            int i = 1;
            foreach (var goal in goals)
            {
                Console.WriteLine($"{i}. {goal.Name} {goal.GetStatusString()}");
                i++;
            }

            Console.Write("Choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > goals.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Goal selected = goals[choice - 1];
            int earned = selected.RecordEvent();

            if (earned > 0)
            {
                score += earned;
                Console.WriteLine($"Event recorded! You earned {earned} points.");
                Console.WriteLine(MotivationalMessages[rand.Next(MotivationalMessages.Length)]);
            }
            else
            {
                Console.WriteLine("Goal already completed or no points awarded.");
            }
        }

        static void SaveGoals()
        {
            try
            {
                using var writer = new StreamWriter(SaveFileName);
                writer.WriteLine(score);
                foreach (var goal in goals)
                {
                    writer.WriteLine(goal.ToDataString());
                }
                Console.WriteLine("Goals saved.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving goals: " + e.Message);
            }
        }

        static void LoadGoals()
        {
            if (!File.Exists(SaveFileName)) return;

            try
            {
                using var reader = new StreamReader(SaveFileName);
                string scoreLine = reader.ReadLine();
                score = int.TryParse(scoreLine, out var s) ? s : 0;

                goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        goals.Add(Goal.FromDataString(line));
                    }
                    catch
                    {
                    
                    }
                }

                Console.WriteLine("Goals loaded.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading goals: " + e.Message);
            }
        }
    }
}
