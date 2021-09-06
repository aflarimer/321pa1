using System;
using System.Collections.Generic;

namespace BigAl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Post> bigAlPosts = PostFile.GetPosts();
            Menu(bigAlPosts);
        }
        static void Menu(List<Post> bigAlPosts) {
            bool choice = false;
            while (choice == false) {
                System.Console.WriteLine("Please choose one of the following options:\n1. Show All Posts\n2. Add a Post\n3. Delete a Post");
                int userInput = int.Parse(Console.ReadLine());
                if (userInput == 1) {
                    Console.Clear();
                    PostUtils.SortFile(bigAlPosts);
                    PostUtils.PrintAllPosts(bigAlPosts);
                    choice = true;
                }
                else if (userInput == 2) {
                    AddPost(bigAlPosts);
                    choice = true;
                }
                else if (userInput == 3) {
                    DeletePost(bigAlPosts);
                    choice = true;
                }
                else {
                    System.Console.WriteLine("Incorrect entry. Please press Enter to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        static void AddPost(List<Post> bigAlPosts) {
            Console.Clear();
            System.Console.WriteLine("Please enter the post's text:");
            string postText = Console.ReadLine();
            bigAlPosts.Add(new Post{PostID = Guid.NewGuid(), PostText = postText, PostTime = DateTime.Now, Deleted = false});
            System.Console.WriteLine("Post was added.");
            PostUtils.SortFile(bigAlPosts);
        }
        static void DeletePost(List<Post> bigAlPosts) {
            Console.Clear();
            PostUtils.PrintAllPosts(bigAlPosts);
            System.Console.WriteLine("\nPlease enter the text of the post you'd like to delete (case sensitive), -1 to cancel.");
            string userEntry = Console.ReadLine();
            bool isFound = false;
            while (!isFound && userEntry != "-1") {
                foreach(Post post in bigAlPosts) {
                    if (userEntry == post.PostText) {
                        isFound = true;
                        post.Deleted = true;
                        System.Console.WriteLine("Post has been deleted.");
                    }
                }
                if (isFound == false) {
                    Console.Clear();
                    Console.WriteLine("Failed to find the post.\n");
                    PostUtils.PrintAllPosts(bigAlPosts);
                    System.Console.WriteLine("\nPlease enter the text of the post you'd like to delete (case sensitive), -1 to cancel.");
                    userEntry = Console.ReadLine();
                }
            }
            PostUtils.SortFile(bigAlPosts);
        }
    }
}
