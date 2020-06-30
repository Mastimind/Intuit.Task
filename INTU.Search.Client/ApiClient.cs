using System;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace INTU.Search.Client
{
    public class FlickrAPIClient:IAPIClient
    {
        private readonly String _apiKey;
        private readonly String _secret;
        private string OAuthAccessToken { get; set; }
        private string OAuthAccessTokenSecret { get; set; }
        
        private const string BaseApiUrl = "https://api.flickr.com/services/rest";
         
        public string LastRequest { get; internal set; }
        public string LastResponse { get; internal set; }

        public FlickrAPIClient(string apiKey, string sharedSecret)
        {
            _apiKey = apiKey;
            _secret = sharedSecret;
        }

        public FlickrAPIClient(string apiKey)
        {
            _apiKey = apiKey;
        }
        public FlickrAPIClient()
        {
            _apiKey = "8940aff3bd4d03534ad5c46f436ad5b3";
            _secret = "9e7ae098e483d1a5";
        }
        
        public async Task<string> GetAll(ISearchParams param)  
        {  
            var imgParam = (ImageSearchParams) param;
            // For the Api Url written below, just get the new Api Url from the flickr api link the blog  
            string provideUri = $"{BaseApiUrl}/?method=flickr.photos.getRecent&api_key={_apiKey}&license=10&sort=relevance&privacy_filter=1&safe_search=1&content_type=4&media=photos&tags={imgParam.SearchText}&&format=json&nojsoncallback=1";  
  
            HttpClient client = new HttpClient();  
            string jsonstring = await client.GetStringAsync(provideUri);  
           /* var obj = JsonConvert.DeserializeObject<RootObject>(jsonstring);  
            if (obj.stat == "ok")  
            {  
                FlickrGridView.ItemsSource = obj.photos.photo;  
            }*/
           return jsonstring;
        }

        public  string GetBySearchParams(ISearchParams param)
        {
            var imgParam = (ImageSearchParams) param;

            var photoUrl = $"https://farm{imgParam.FarmId}.staticflickr.com/{imgParam.ServerId}/{imgParam.Id}_{imgParam.Secret}";
        //    var r = new BitMapImage(photoUrl);
            return photoUrl;
        }
    }
    
    public class TwitterClient:IAPIClient
    {
        public async Task<string> GetAll(ISearchParams param)
        {
            throw new NotImplementedException();
        }

        public string GetBySearchParams(ISearchParams param)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAPIClient
    {
        Task<string> GetAll(ISearchParams param);
        string GetBySearchParams(ISearchParams param);
    }
}