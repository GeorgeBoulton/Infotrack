namespace Infotrack.Models
{
    public class SearchRequest
    {
        public string Keywords { get; set; }
        public string SearchUrl { get; set; } = "https://google.com/search?num=100&q=";

        public string FormatTerms()
        {
            return $"{this.SearchUrl}{Keywords.Replace(" ", "+")}";
        }
    }
}
