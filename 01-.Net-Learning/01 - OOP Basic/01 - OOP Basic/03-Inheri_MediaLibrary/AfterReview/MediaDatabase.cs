using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._03_Inheri_MediaLibrary.AfterReview
{
    internal class MediaDatabase
    {
        private List<MediaItem> _mediaItems = new List<MediaItem>();
        public void Add(MediaItem item)
        {
            _mediaItems.Add(item);
        }

        public void PrintAllMedia()
        {
            foreach (var item in _mediaItems)
            {
                item.Print();
            }
        }
    }
}
