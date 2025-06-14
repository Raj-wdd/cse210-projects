using System; using System.Diagnostics.Tracing; using System.IO.Compression;

class Program
{
        private static void Main(string[] args)
        {
                // Console.WriteLine("Yo, Bob");

                int sleepTime = 250;
                int time = 9;

                DateTime currentTime = DateTime.Now;
                DateTime endtime = currentTime.AddSeconds(time);

                int count = time;

                while (DateTime.Now < endtime)
                {
                        Console.Write(count--);
                        Thread.Sleep(1000);
                        Console.Write("\b");

                }
                string animationString = "(^_^)(-_-)";

                while (DateTime.Now < endtime)
                {
                        Console.Write(animationString[0..5]);
                        Thread.Sleep(sleepTime);
                        Console.Write("\b\b\b\b\b\b");
                        Console.Write(animationString[5..]);
                        Console.Write("-");
                        Thread.Sleep(sleepTime);
                        Console.Write("\b\b\b\b\b");

                }
        }
}

        