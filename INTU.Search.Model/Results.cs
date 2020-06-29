using System;

namespace INTU.Search.Model
{
    public class ImagesResult
    {
        public string ImageName { get; set; }
        public string Uri { get; set; }
        public string Thumbnails { get; set; }
    }

    public class TweetsResult
    {
        public string Tweet { get; set; }
        public string Uri { get; set; }
        public string  User { get; set; }
    }
}
