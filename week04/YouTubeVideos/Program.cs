using System;

class Program
{
    static void Main(string[] args)
    {
        // we create videos and comments
        Video video1 = new Video("Introduction to programming", "Luis Juarez", 500);
        video1.AddComment(new Comment("Sharon", "Thank you for the video"));
        video1.AddComment(new Comment("Maria", "It was a great video"));
        video1.AddComment(new Comment("Leonor", "thank you so much for this video"));

        Video video2 = new Video("Learn Korean", "Kim Seokjin", 700);
        video2.AddComment(new Comment("Patricia", "I have learned more Korean, thank you."));
        video2.AddComment(new Comment("Jennifer", "great video!"));
        video2.AddComment(new Comment("Franco", "It helped me, thank you"));
        video2.AddComment(new Comment("Mariela", "this videos help me to understand more!"));

        Video video3 = new Video("Learn to cook", "Alicia Dominguez", 600);
        video3.AddComment(new Comment("Juan Fernandez", "I have developed my talent!"));
        video3.AddComment(new Comment("Jorge Duran", "My family loved it, thank you"));
        video3.AddComment(new Comment("Luisa Martinez", "Thanks for the video, it helped me"));

        List<Video> videos = new List<Video> {video1, video2, video3}; // we add the videos to a list

        foreach (var video in videos) // We go through the list and display the information
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}