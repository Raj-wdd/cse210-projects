public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly.") {}

    public override void PerformActivity()
    {
        Start();
        int duration = GetDuration();
        int cycleTime = 6; // 3 sec in + 3 sec out
        int cycles = duration / cycleTime;

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(3);
            Console.Write("Breathe out... ");
            ShowCountdown(3);
        }

        End();
    }
}
