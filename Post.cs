using System;
using System.Collections.Generic;
namespace BigAl
{
    public class Post
    {
        public Guid PostID {get; set;}
        public string PostText {get; set;}
        public DateTime PostTime {get; set;}
        public bool Deleted {get; set;}

        public static int CompareByDate(Post x, Post y) { //class method to compare each post by datetime for the sort
            return x.PostTime.CompareTo(y.PostTime);
        }

        public override string ToString() {
            return "Big Al's post saying '" + this.PostText + "' was posted on " + this.PostTime + " and has an ID of " + this.PostID + ".";
        }
        public string Delimited() {
            return this.PostID + "#" + this.PostText + "#" + this.PostTime + "#" + this.Deleted;
        }

        
    }
}