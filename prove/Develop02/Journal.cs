using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        File.WriteAllLines(filename, _entries.Select(e => e.ToFileString()));
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            _entries.Add(Entry.FromFileString(line));
        }
    }
}
