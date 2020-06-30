namespace INTU.Search.Client
{
    public class SearchParamFactory :IParamFactory
    {
        public ISearchParams CreateParams(string apiType)
        {
            ISearchParams _parameter = null;
            if (apiType == "Flicker")
            {
                
            }else if (apiType == "Twitter")
            {
                
            }

            return _parameter;
        }
    }

    public interface IParamFactory
    {
        ISearchParams CreateParams(string apiType);
    }
}