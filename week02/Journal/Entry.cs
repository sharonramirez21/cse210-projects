using System.Formats.Asn1;

// Showing Creativity and Exceeding Requirements
// Save other information in the journal entry. I chose add Mood :)
public class Entry
{
    public string _date { get; set; }
    public string _promts { get; set; }
    public string _answer { get; set; }

    public string _mood { get; set;}

    public Entry(string date, string prompt, string answer, string mood)
    {
        _date = date;
        _promts = prompt;
        _answer = answer;
        _mood = mood;
    }
}
