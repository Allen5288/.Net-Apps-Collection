using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic.Inheri_MediaLibrary
{
    public class DVD
    {
        private string title;
        private string director;
        private int playingTime;
        private bool gotIt;
        private string comment;

        public DVD(string title, string director, string comments)
        {
            this.title = title;
            this.director = director;
            this.playingTime = 0;
            this.gotIt = false;
            this.comment = comments;
        }

        public void Print()
        {
            Console.WriteLine($"{title} {director} {playingTime} {comment}");
        }
    }
}
