using System;
using System.Linq;
using Caliburn.Micro;
using INTU.Search.Business;
using INTU.Search.Client;
using INTU.Search.Model;

namespace INTU.Search.ViewModel
{
    public class ImageResultViewModel
    {
        private IFlickrBusiness _businees;
        public BindableCollection<ImagesResult> ImagesResults { get; set; }

        public ImageResultViewModel()
        {
            _businees= new FlickrBusiness(new ClientFactory());
             ImagesResults= new BindableCollection<ImagesResult>();       
        }

        public async void SearchImage(string text,int size =100)
        {
            var result = await _businees.GetImagesBySearchParams(text);
            
            ImagesResults.AddRange(result.Take(size));
        }
    }
}