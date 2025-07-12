public class TemperatureData : WeatherData
{
    private int high;
    private int low;

    public TemperatureData(int high, int low)
    {
        this.high = high;
        this.low = low;
    }

    public int GetHigh() => high;
    public int GetLow() => low;
    public int GetAverage() => (high + low) / 2;

    public override string Type => "Temperature";
    public override string GetSummary() => $"High: {high}°C, Low: {low}°C, Avg: {GetAverage()}°C";
}
