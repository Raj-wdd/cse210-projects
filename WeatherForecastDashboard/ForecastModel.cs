using System;

public abstract class ForecastModel
{
    public abstract WeatherDay GenerateForecast(DateTime date);
}
