class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                _ => null
            };

            if (choice == "5")
                break;

            if (choice == "4")
            {
                ShowLog();
                continue;
            }

            if (activity == null)
            {
                Console.WriteLine("Invalid choice.");
                Thread.Sleep(1000);
                continue;
            }

            activity.PerformActivity();
        }
    }

    static void ShowLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log:\n");
        if (File.Exists("activity_log.txt"))
        {
            string log = File.ReadAllText("activity_log.txt");
            Console.WriteLine(log);
        }
        else
        {
            Console.WriteLine("No activities logged yet.");
        }
        Console.WriteLine("\nPress any key to return to menu.");
        Console.ReadKey();
    }
}