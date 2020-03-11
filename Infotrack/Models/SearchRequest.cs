namespace Infotrack.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SearchRequest
    {
        private const string SearchUrl = "https://google.com/search?num=100&q=";

        [Required]
        [MaxLength(160, ErrorMessage = SearchRequestErrors.KeywordsErrorMessage)]
        public string Keywords { get; set; }

        [Required]
        [RegularExpression(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?", ErrorMessage = SearchRequestErrors.FilterUrlErrorMessage)]
        public string FilterUrl { get; set; }

        public string GetQueryUrl()
        {
            return $"{SearchUrl}{Keywords.Replace(" ", "+")}";
        }
    }
}
