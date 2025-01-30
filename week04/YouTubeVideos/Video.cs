class Video 
{
    public string Title;
    public string Author;
    public int Duration;
    private List<Comment> Comments = new List<Comment>();

    public Video(string title, string author, int duration)
    {
        Title = title;
        Author = author;
        Duration = duration;
    }

    public void AddComment(Comment comment) // we add a commment in the list
    {
        Comments.Add(comment);
    }

    public int GetCommentCount() // retunr the total number of comments
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title:{Title}, Author: {Author}, Duration: {Duration}");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        foreach (var comment in Comments)
        {
            comment.DisplayComment(); // show all comments
        }
    }
}