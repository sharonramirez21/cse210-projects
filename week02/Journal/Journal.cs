using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries { get; set;}

    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Write a new entry
    public void AddEntry()
    {
        var prompts = new List<string>
        {
           "Who was the most interesting person I interacted with today?",
           "What was the best part of my day?",
           "How did I see the hand of the Lord in my life today?",
           "What was the strongest emotion I felt today?",
           "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine($"Promt: {prompt}");
        Console.WriteLine("Write your answer: ");
        string answer = Console.ReadLine();
        string Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // i ask the user how was his day today and i saved in the string mood
        Console.Write("How was your mood today?: ");
        string mood = Console.ReadLine();

        Entry newEntry = new Entry(Date, prompt, answer, mood);
        _entries.Add(newEntry);
    }

    // Display the journal - Iterate through all entries in the journal and display them to the screen
    public void DisplayJournal()
    {
       foreach (var Entry in _entries)
       {
            Console.WriteLine($"Date: {Entry._date}, Promt: {Entry._promts}");
            Console.WriteLine($"Answer: {Entry._answer}");
            Console.WriteLine($"Mood: {Entry._mood}"); // i show the user mood
       }
    } 


    // Save the journal to a file - Prompt the user for a filename and then save the current journal
    //(the complete list of entries) to that file location.
    public void SaveJournal()
    {
        Console.WriteLine("What is the filename? (e.g., diary.txt): ");
        string filename = Console.ReadLine();

        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt";
        }

        string directoryPath = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(directoryPath, filename); // which directory is saved?

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine("Date,Prompt,Answer,Mood"); // i add the mood in the top of the file

                if (_entries.Count == 0)
                {
                    Console.WriteLine("No entries to save.");
                    return;
                }

                foreach (var Entry in _entries)
                {
                    string prompt = Entry._promts.Replace(",", "\\,").Replace("\"", "\\\"");
                    string answer = Entry._answer.Replace(",", "\\,").Replace("\"", "\\\"");
                    string mood = Entry._mood.Replace(",", "\\,").Replace("\"", "\\\"");

                    outputFile.WriteLine($"{Entry._date},{Entry._promts},{Entry._answer},{Entry._mood}");
                }
            }

            Console.WriteLine($"The journal has been successfully saved to: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    // Load the journal from a file - Prompt the user for a filename and then load the journal
    //(a complete list of entries) from that file. This should replace any entries currently stored the journal.
    public void LoadJournal()
    {
        Console.WriteLine("What is the filename?: ");
        string NameFilename = Console.ReadLine();

        if (!File.Exists(NameFilename))
        {
            Console.WriteLine($"The file was not found.");
            return;
        }

        string[] lines = File.ReadAllLines(NameFilename);
        _entries.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(',');

            if (parts.Length == 4)
            {
                string date = parts[0];
                string prompt = parts[1];
                string answer = parts[2];
                string mood = parts[3];

                Entry newEntry = new Entry(date, prompt, answer, mood);
                _entries.Add(newEntry);
            }
        }
        Console.WriteLine("Journal loaded successfully! Here are the entries:");
        foreach (var Entry in _entries)
        {
            Console.WriteLine($"Date: {Entry._date}");
            Console.WriteLine($"Prompt: {Entry._promts}");
            Console.WriteLine($"Answer: {Entry._answer}");
            Console.WriteLine($"Mood: {Entry._mood}");
            Console.WriteLine(); 
        }
    }
}