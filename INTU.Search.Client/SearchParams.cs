namespace INTU.Search.Client
{
    public class ImageSearchParams:ISearchParams
    {
        public string Id { get; set; }
        public string Secret { get; set; }

        public int FarmId { get; set; }
        public string ServerId { get; set; }
        
        public string SearchText { get; set; }

    }

    public interface ISearchParams
    {
        
    }
}