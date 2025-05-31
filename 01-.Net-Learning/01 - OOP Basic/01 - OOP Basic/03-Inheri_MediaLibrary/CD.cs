using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic.Inheri_MediaLibrary
{
    public class CD
    {
        private string title;
        private string artist;
        private int numberOfTracks;
        private int playingTime;
        private bool gotIt;
        private string comment;

        public CD(string title, string artist, int numberOfTracks, string comment)
        {
            this.title = title;
            this.artist = artist;
            this.numberOfTracks = numberOfTracks;
            this.playingTime = 0;
            this.gotIt = false;
            this.comment = comment;
        }

        public void Print()
        {
            Console.WriteLine($"{title} {artist} {numberOfTracks} {playingTime} {comment}");
        }
    }
}
