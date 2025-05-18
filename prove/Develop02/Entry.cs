using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }

    public Entry(string prompt, string response, string mood)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nMood: {Mood}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToFileString()
    {
        return $"{Date}|{Prompt}|{Response}|{Mood}";
    }

    public static Entry FromFileString(string line)
    {
        var parts = line.Split('|');
        return new Entry(parts[1], parts[2], parts[3]) { Date = parts[0] };
    }
}
