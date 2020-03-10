namespace Infotrack.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class GoogleReader : IGoogleReader
    {
        private const string Pattern = @"<div class=""BNeawe UPmit AP7Wnd"">(.*?) ";

        public async Task<string> GetResults(string scrapeUrl, string filterUrl)
        {
            
            var results = await this.ScrapeSearchResults(scrapeUrl);
            var resultsList = this.ParseSearchResultsToList(results);

            return this.GetResultsFoundString(resultsList, filterUrl);
        }


        private async Task<string> ScrapeSearchResults(string url)
        {
            var client = new HttpClient();

            return await client.GetStringAsync(url);
        }

        private List<string> ParseSearchResultsToList(string input)
        {
            Regex regex = new Regex(Pattern);

            var resultsList = regex.Matches(input)
                                   .Select(m => m.Value)
                                   .ToList();

            return resultsList;
        }

        private string GetResultsFoundString(List<string> results, string filterUrl)
        {
            StringBuilder resultsFoundStringBuilder = new StringBuilder();

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].Contains(filterUrl))
                {
                    resultsFoundStringBuilder.Append($"{i + 1}, ");
                }
            }

            int length = resultsFoundStringBuilder.Length;

            if (length != 0)
            {
                return resultsFoundStringBuilder.Remove(length - 2, 2).ToString();
            }

            return "0";
        }
    }
}
