public class HumidityData : WeatherData
{
    private int humidity;

    public HumidityData(int humidity)
    {
        this.humidity = humidity;
    }

    public int GetHumidity() => humidity;

    public override string Type => "Humidity";
    public override string GetSummary() => $"Humidity: {humidity}%";
}
