using System;
using System.IO;
using System.Collections.Generic;
namespace BigAl

{
    public class PostFile
    {
        public static List<Post> GetPosts() { //reads in the posts.txt file to make the Post list
            List<Post> bigAlPosts = new List<Post>();
            StreamReader inFile = null;
            try {
                inFile = new StreamReader("posts.txt");
            }
            catch (FileNotFoundException e){
                System.Console.WriteLine("Something went wrong. System will now return a blank list {0}" + e);
                return bigAlPosts;
            }

            string line = inFile.ReadLine();
            while (line != null) {
                string[] temp = line.Split('#');
                Guid postID = Guid.Parse(temp[0]);
                DateTime postTime = DateTime.Parse(temp[2]);
                bool deleted = bool.Parse(temp[3]);
                bigAlPosts.Add(new Post{PostID = postID, PostText = temp[1], PostTime = postTime, Deleted = deleted});
                line = inFile.ReadLine();
            }
            inFile.Close();
            return bigAlPosts;
            
        }
        public static void PrintToFile(List<Post> bigAlPosts) { //prints the Post list to the posts.txt file
            StreamWriter outFile = new StreamWriter("posts.txt");
            foreach (Post post in bigAlPosts) {
                outFile.WriteLine(post.Delimited());
            }
            outFile.Close();
        }

    }
}