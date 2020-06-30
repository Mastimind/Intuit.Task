using System;

namespace INTU.Search.Model
{
    public class ImagesResult
    {
        private string _uri;
        public ImagesResult(string uri)
        {
            _uri = uri;
        }
        public Uri ImageName => string.IsNullOrEmpty(_uri) ? null : new Uri($"{_uri}_n.jpg");

        public string Uri => _uri;

        public Uri Thumbnails => string.IsNullOrEmpty(_uri) ? null : new Uri($"{_uri}_t.jpg");
    }

    public class TweetsResult
    {
        public string Tweet { get; set; }
        public string Uri { get; set; }
        public string  User { get; set; }
    }
}
