public class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can.") {}

    public override void PerformActivity()
    {
        Start();

        Console.WriteLine("\n--- Prompt ---");
        Console.WriteLine(GetRandomPrompt());

        Console.WriteLine("\nYou may begin in:");
        ShowCountdown(5);

        Console.WriteLine("Start listing items (press ENTER after each one):");
        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        int count = 0;

        while (DateTime.Now < end)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} items!");
        End();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
