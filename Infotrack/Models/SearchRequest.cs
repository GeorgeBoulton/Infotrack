namespace Infotrack.Models
{
    public class SearchRequest
    {
        private const string SearchUrl = "https://google.com/search?num=100&q=";

        public string Keywords { get; set; }

        public string FilterUrl { get; set; }

        public string GetQueryUrl()
        {
            return $"{SearchUrl}{Keywords.Replace(" ", "+")}";
        }
    }
}
