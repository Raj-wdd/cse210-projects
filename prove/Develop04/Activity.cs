public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long (in seconds) would you like to do this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
        LogActivity();
    }

    private void LogActivity()
    {
        string logEntry = $"{DateTime.Now}: Completed {_name} for {_duration} seconds.";
        File.AppendAllText("activity_log.txt", logEntry + Environment.NewLine);
    }

    public int GetDuration() => _duration;

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write($"\r{spinner[i % spinner.Length]}");
            Thread.Sleep(200);
            i++;
        }
        Console.Write("\r ");
    }

    public abstract void PerformActivity();
}
