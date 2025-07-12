using System;
using System.Collections.Generic;
using System.Linq;

public class WeatherStats
{
    private List<WeatherDay> days;

    public WeatherStats(List<WeatherDay> days)
    {
        this.days = days;
    }

    public void DisplayStats()
    {
        if (!days.Any())
        {
            Console.WriteLine("No weather data available.");
            return;
        }

        double avgTemp = days.Average(d => d.Temperature.GetAverage());
        double avgHumidity = days.Average(d => d.Humidity.GetHumidity());
        double avgWind = days.Average(d => d.Wind.GetSpeed());

        Console.WriteLine($"Avg Temp: {avgTemp:F1}°C");
        Console.WriteLine($"Avg Humidity: {avgHumidity:F1}%");
        Console.WriteLine($"Avg Wind Speed: {avgWind:F1} km/h\n");
    }
}
