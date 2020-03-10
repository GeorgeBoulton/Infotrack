using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infotrack.Controllers
{
    using Infotrack.Models;
    using Infotrack.Services;

    public class SearchController : Controller
    {
        private readonly IGoogleReader googleReader;

        public SearchController(IGoogleReader googleReader)
        {
            this.googleReader = googleReader;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string keywords, string filterUrl)
        {
            var searchRequest = new SearchRequest
            {
                Keywords = keywords,
                FilterUrl = filterUrl
            };

            ViewData["Results"] = await this.googleReader.GetResults(searchRequest.GetQueryUrl(), searchRequest.FilterUrl);
            
            return View();
        }
    }
}
