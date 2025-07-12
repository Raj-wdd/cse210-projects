using System;
using System.Collections.Generic;

public class ConsoleUI
{
    private WeatherTracker tracker = new WeatherTracker();
    private ForecastModel model;
    private Location location;

    private readonly List<string> allowedLocations = new List<string>
        { "New York", "London", "Tokyo", "Paris", "Sydney" };

    public void Run()
    {
        Console.WriteLine("=== Weather Forecast Dashboard ===\n");

        location = GetValidLocation();

        Console.WriteLine("\nUsing Random Forecast Model.\n");
        model = new RandomForecastModel();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. View Today's Forecast");
            Console.WriteLine("2. View 7-Day Forecast");
            Console.WriteLine("3. View Weather Statistics");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ForecastToday();
                    break;
                case "2":
                    ForecastWeek();
                    break;
                case "3":
                    ShowStats();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    private Location GetValidLocation()
    {
        while (true)
        {
            Console.WriteLine("Please select your location from the following list:");
            for (int i = 0; i < allowedLocations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allowedLocations[i]}");
            }
            Console.Write("Enter location name exactly as above: ");
            string input = Console.ReadLine();

            foreach (var loc in allowedLocations)
            {
                if (string.Equals(input, loc, StringComparison.OrdinalIgnoreCase))
                {
                    return new Location(loc);
                }
            }

            Console.WriteLine("Invalid location. Please try again.\n");
        }
    }

    private void ForecastToday()
    {
        var today = DateTime.Today;
        var forecast = model.GenerateForecast(today);
        tracker.AddDay(forecast);
        Console.WriteLine($"\nWeather forecast for {location}:\n");
        forecast.Display();
    }

    private void ForecastWeek()
    {
        Console.WriteLine($"\n7-day weather forecast for {location}:\n");
        for (int i = 0; i < 7; i++)
        {
            var date = DateTime.Today.AddDays(i);
            var forecast = model.GenerateForecast(date);
            tracker.AddDay(forecast);
            forecast.Display();
        }
    }

    private void ShowStats()
    {
        Console.WriteLine($"\nWeather statistics for {location} (based on generated data):\n");
        var stats = new WeatherStats(tracker.GetAllDays());
        stats.DisplayStats();
    }
}
