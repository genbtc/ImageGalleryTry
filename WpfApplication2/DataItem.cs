using System;

namespace GalleryTry
{
    public class DataItem
    {
        private readonly string _title;
        private readonly Uri _picture;

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public Uri Picture
        {
            get
            {
                return _picture;
            }
        }

        //constructor without title.
        public DataItem(string picture)
        {
            //_title = title;
            _picture = new Uri(picture, UriKind.Absolute);
        }
        
        public DataItem(string title, string picture)
        {
            _title = title;
            _picture = new Uri(picture, UriKind.Absolute);
        }
    }
}