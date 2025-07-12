using System;
using System.Collections.Generic;

public class WeatherTracker
{
    private List<WeatherDay> history = new List<WeatherDay>();

    public void AddDay(WeatherDay day)
    {
        history.Add(day);
    }

    public List<WeatherDay> GetAllDays()
    {
        return history;
    }
}
