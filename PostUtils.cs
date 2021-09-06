using System;
using System.Collections.Generic;
namespace BigAl
{
    public class PostUtils
    {
        public static void PrintAllPosts(List<Post> bigAlPosts) { //prints all non-deleted posts to the terminal
            foreach(Post post in bigAlPosts) {
                if (post.Deleted != true) {
                    Console.WriteLine(post.ToString());
                }
            }
        }
        public static void SortFile(List<Post> bigAlPosts) { //prints the sorted list in descending order to the posts.txt file
            bigAlPosts.Sort(Post.CompareByDate);
            bigAlPosts.Reverse();
            PostFile.PrintToFile(bigAlPosts);
        }
    }
}