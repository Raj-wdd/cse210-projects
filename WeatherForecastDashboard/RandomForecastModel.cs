using System;

public class RandomForecastModel : ForecastModel
{
    private Random rand = new Random();

    public override WeatherDay GenerateForecast(DateTime date)
    {
        var temp = new TemperatureData(rand.Next(20, 40), rand.Next(10, 20));
        var humidity = new HumidityData(rand.Next(40, 90));
        var wind = new WindData(rand.Next(5, 25));
        return new WeatherDay(date, temp, humidity, wind);
    }
}
