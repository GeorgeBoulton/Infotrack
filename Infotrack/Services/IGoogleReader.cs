using System.Threading.Tasks;

namespace Infotrack.Services
{
    public interface IGoogleReader
    {
        Task<string> GetResults(string scrapeUrl, string filterUrl);
    }
}