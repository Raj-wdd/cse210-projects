using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Selecting a random scripture from a library of verses.
var scriptures = new List<Scripture>
{
    new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy."),

    new Scripture(new Reference("Mosiah", 2, 17), "When ye are in the service of your fellow beings ye are only in the service of your God."),

    new Scripture(new Reference("Alma", 37, 6), "By small and simple things are great things brought to pass."),

    new Scripture(new Reference("Ether", 12, 27), "And if men come unto me I will show unto them their weakness."),

    new Scripture(new Reference("Doctrine and Covenants", 6, 36), "Look unto me in every thought; doubt not, fear not."),

    new Scripture(new Reference("Romans", 8, 28), "And we know that all things work together for good to them that love God."),

    new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),

    new Scripture(new Reference("Matthew", 5, 16), "Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven."),

    new Scripture(new Reference("James", 1, 5), "If any of you lack wisdom, let him ask of God."),

    new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want.")
};


        var random = new Random();
        var scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words hidden. Great job memorizing!");
                break;
            }
        }
    }
}
