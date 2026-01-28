using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("C# Basics Tutorial", "John Smith", 1200);
        video1.AddComment(new Comment("Alice", "Great explanation of classes!"));
        video1.AddComment(new Comment("Bob", "This really helped me understand inheritance."));
        video1.AddComment(new Comment("Charlie", "Thanks for the clear examples!"));
        video1.AddComment(new Comment("Diana", "Best tutorial I've found so far."));
        videos.Add(video1);

        // Create Video 2
        Video video2 = new Video("Web Development with .NET", "Sarah Johnson", 1800);
        video2.AddComment(new Comment("Eve", "Very informative and well-structured."));
        video2.AddComment(new Comment("Frank", "I finally understand async/await!"));
        video2.AddComment(new Comment("Grace", "Would love to see more advanced topics."));
        videos.Add(video2);

        // Create Video 3
        Video video3 = new Video("Data Structures Explained", "Mike Davis", 2400);
        video3.AddComment(new Comment("Henry", "The visualization of trees was super helpful."));
        video3.AddComment(new Comment("Ivy", "Excellent breakdown of algorithms."));
        video3.AddComment(new Comment("Jack", "Finally understand big O notation!"));
        video3.AddComment(new Comment("Kate", "Can't wait for the next part."));
        videos.Add(video3);

        // Create Video 4
        Video video4 = new Video("Object-Oriented Programming Principles", "Emma Wilson", 1500);
        video4.AddComment(new Comment("Leo", "Polymorphism explanation was crystal clear."));
        video4.AddComment(new Comment("Megan", "Best OOP tutorial ever."));
        video4.AddComment(new Comment("Noah", "Thank you for making this so understandable."));
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine(); // Blank line for readability
        }
    }
}

