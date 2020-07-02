using System;
using System.Collections.ObjectModel;
using System.Linq;
using INTU.Search.Business;
using INTU.Search.Client;
using INTU.Search.Model;

namespace INTU.Search.ViewModel
{
    public class ImageResultViewModel
    {
        private IFlickrBusiness _businees;
        public ObservableCollection<ImagesResult> ImagesResults { get; set; }

        public ImageResultViewModel()
        {
            _businees= new FlickrBusiness(new ClientFactory());
             ImagesResults= new ObservableCollection<ImagesResult>();
             ImagesResults.Add(new ImagesResult("testing"));
        }

        public async void SearchImage(string text,int size =100)
        {
            ImagesResults= new ObservableCollection<ImagesResult>();
            
            var result = await _businees.GetImagesBySearchParams(text);
            
            result.Take(size).ToList().ForEach(i=> ImagesResults.Add(i));
        }
    }
}