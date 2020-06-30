using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using INTU.Search.Client;
using INTU.Search.Model;
using Newtonsoft.Json;

namespace INTU.Search.Business
{
    public class FlickrBusiness:IFlickrBusiness
    {
        private readonly IAPIClient _client;
        public FlickrBusiness(IClientFactory factory)
        {
            _client = factory.Create("Flicker");
        }
        
        private async Task<FlickrData> GetImagesBySearchParams(ISearchParams searchParam)
        {
            var jsonResult = await _client.GetAll(searchParam);
            var result = JsonConvert.DeserializeObject<FlickrData>(jsonResult);

            return result;
        }
        

        private string GetImageUrlByImageParam(Photo info)
        {
            var param = new ImageSearchParams()
            {
                Id = info.id, FarmId = info.farm, Secret = info.secret,
                ServerId = info.server
            };

            return _client.GetBySearchParams(param);
        }

        public async Task<IEnumerable<ImagesResult>> GetImagesBySearchParams(string searchText)
        {
            var searchParam =new ImageSearchParams();
            searchParam.SearchText = searchText;
            var filckrData = await GetImagesBySearchParams(searchParam);
            var result = filckrData.photos.photo.
                Select(p=>new ImagesResult(GetImageUrlByImageParam(p))).ToList();
            return result;
        }
    }

    public interface IFlickrBusiness
    {
        Task<IEnumerable<ImagesResult>> GetImagesBySearchParams(string searchText);
        
    }
}