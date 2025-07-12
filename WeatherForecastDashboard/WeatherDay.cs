using System;
using System.Collections.Generic;

public class WeatherDay
{
    public DateTime Date { get; private set; }
    public TemperatureData Temperature { get; private set; }
    public HumidityData Humidity { get; private set; }
    public WindData Wind { get; private set; }

    public WeatherDay(DateTime date, TemperatureData temp, HumidityData humidity, WindData wind)
    {
        Date = date;
        Temperature = temp;
        Humidity = humidity;
        Wind = wind;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date.ToShortDateString()}");
        Console.WriteLine(Temperature.GetSummary());
        Console.WriteLine(Humidity.GetSummary());
        Console.WriteLine(Wind.GetSummary());
        Console.WriteLine();
    }
}
