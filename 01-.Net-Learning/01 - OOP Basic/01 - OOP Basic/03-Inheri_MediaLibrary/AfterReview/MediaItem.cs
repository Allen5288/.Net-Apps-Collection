using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._03_Inheri_MediaLibrary.AfterReview
{
    public class MediaItem
    {
        protected string title;
        protected int playingTime;
        protected bool gotIt;
        protected string comment;

        public MediaItem(string title, int playingTime, bool gotIt, string comment)
        {
            this.title = title;
            this.playingTime = playingTime;
            this.gotIt = gotIt;
            this.comment = comment;
        }

        public virtual void Print()
        {
            
            Console.WriteLine($"{title} {playingTime} {gotIt} {comment}");
        }

    }
}
