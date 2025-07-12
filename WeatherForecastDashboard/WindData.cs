public class WindData : WeatherData
{
    private int speed;

    public WindData(int speed)
    {
        this.speed = speed;
    }

    public int GetSpeed() => speed;

    public override string Type => "Wind";
    public override string GetSummary() => $"Wind Speed: {speed} km/h";
}
