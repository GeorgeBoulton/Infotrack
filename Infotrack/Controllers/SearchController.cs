using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infotrack.Controllers
{
    using System.Diagnostics;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchRequest searchRequest)
        {
            if (ModelState.IsValid)
            {
                ViewData["Results"] = await this.googleReader.GetResults(searchRequest.GetQueryUrl(), searchRequest.FilterUrl);

                return View();
            }
            return View(searchRequest);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
