class Comment
{
    public string Name; //name of the user
    public string Text; // comment

    public Comment (string name, string text)
    {
        Name = name;
        Text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"Comment by: {Name}, {Text}");
    }
}