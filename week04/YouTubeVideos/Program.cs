using System;
using System.Collections.Generic;

// This program shows off abstraction: instead of juggling lots of loose
// variables, we create Video and Comment objects and let each class
// look after its own information.
class Program
{
    static void Main(string[] args)
    {
        // This list will hold all of our videos
        List<Video> videos = new List<Video>();

        // ----- Video 1 -----
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeWithAnna", 600);
        video1.AddComment(new Comment("Sam", "Great overview, very clear!"));
        video1.AddComment(new Comment("Tariro", "This helped me finish my homework."));
        video1.AddComment(new Comment("Liam", "Can you do one on classes next?"));
        videos.Add(video1);

        // ----- Video 2 -----
        Video video2 = new Video("Intro to SQL Joins", "DataDan", 845);
        video2.AddComment(new Comment("Maya", "Finally understand INNER vs LEFT JOIN."));
        video2.AddComment(new Comment("Chen", "The diagrams were super helpful."));
        video2.AddComment(new Comment("Ruth", "Please make a part 2!"));
        videos.Add(video2);

        // ----- Video 3 -----
        Video video3 = new Video("Excel Tips for Analysts", "SheetSense", 420);
        video3.AddComment(new Comment("Ben", "The pivot table section was gold."));
        video3.AddComment(new Comment("Nomsa", "Shortcuts saved me so much time."));
        video3.AddComment(new Comment("Ivan", "Subscribed after this one."));
        videos.Add(video3);

        // Now go through every video and print its details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            // Print each comment that belongs to this video
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }

            // Blank line to keep the videos visually separated
            Console.WriteLine();
        }
    }
}
