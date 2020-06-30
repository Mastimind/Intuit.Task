namespace INTU.Search.Client
{
    public class ClientFactory: IClientFactory
    {
        public IAPIClient Create(string apiType)
        {
            IAPIClient _client = null;
            if (apiType == "Flicker")
            {
             _client= new FlickrAPIClient();   
            }else if (apiType == "Twitter")
            {
                
            }

            return _client;
        }
    }

    public interface IClientFactory
    {
        IAPIClient Create(string apiType);
    }
}