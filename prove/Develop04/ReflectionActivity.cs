public class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind?"
    };

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.") {}

    public override void PerformActivity()
    {
        Start();
        Console.WriteLine("\n--- Prompt ---");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine();

        int timeLeft = GetDuration();
        Random rand = new Random();

        while (timeLeft > 5)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5);
            timeLeft -= 5;
        }

        End();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
