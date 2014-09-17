using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using MoreLinq;

namespace GalleryTry
{
    public class ViewModel : INotifyPropertyChanged
    {
        public IEnumerable<List<DataItem>> Images2 { get; private set; }
        public IEnumerable<List<DataItem>> Images { get; private set; }

        public ViewModel()
        {
            var photospathlist = Directory.EnumerateFiles(@"C:\Users\EOFL\Pictures", "*.jpg", SearchOption.AllDirectories); 

            IEnumerable<DataItem> dataitemlist = photospathlist.Select(file => new DataItem(file));
            IEnumerable<DataItem> dataItems = dataitemlist as DataItem[] ?? dataitemlist.ToArray();

            
            Images = dataItems.Batch(3).Select(x => x.ToList());
            RaisePropertyChanged("Images");
            Images2 = dataItems.Batch(1).Select(x => x.ToList());
            RaisePropertyChanged("Images2");
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
