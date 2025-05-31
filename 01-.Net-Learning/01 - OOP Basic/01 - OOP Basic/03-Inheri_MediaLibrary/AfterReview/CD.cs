using _01___OOP_Basic._03_Inheri_MediaLibrary.AfterReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._03_Inheri_MediaLibrary.AfterReview
{
    public class CD : MediaItem
    {
        private string artist;
        private int numberOfTracks; 
        
        public CD(string title, string artist, int numberOfTracks, string comment)
            : base(title, 0, false, comment)
        {
            this.artist = artist;
            this.numberOfTracks = numberOfTracks;
        }

        public void Print()
        {
            Console.WriteLine($"{title} {artist} {numberOfTracks} {playingTime} {comment}");
        }
    }
}
