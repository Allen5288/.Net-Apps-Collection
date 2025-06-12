using _01___OOP_Basic._03_Inheri_MediaLibrary.AfterReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._03_Inheri_MediaLibrary.AfterReview
{
    public class DVD : MediaItem
    {
        private string director;
        
        public DVD(string title, string director, string comments)
            : base(title, 0, false, comments)
        {
            this.director = director;
        }

        // new here indicates that we are hiding the base class method
        public new void Print()
        {
            Console.WriteLine($"{title} {director} {playingTime} {comment}");
        }
    }
}
