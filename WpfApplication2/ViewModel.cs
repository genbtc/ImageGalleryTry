using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using MoreLinq;

namespace GalleryTry
{
    public class ViewModel : INotifyPropertyChanged
    {
        public IEnumerable<List<DataItem>> Images { get; private set; }

        public ViewModel()
        {
            var photospathlist = Directory.EnumerateFiles(@"C:\Users\EOFL\Pictures", "*.jpg", SearchOption.AllDirectories); 

            IEnumerable<DataItem> dataitemlist = photospathlist.Select(file => new DataItem(file));

            Images = dataitemlist.Batch(3).Select(x => x.ToList());
            RaisePropertyChanged("Images");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
