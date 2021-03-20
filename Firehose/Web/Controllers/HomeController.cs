using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Firehose.Web.Models;
using Firehose.Web.Infrastructure;

namespace Firehose.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAmACommunityMember[] _members;

        public HomeController(ILogger<HomeController> logger, IEnumerable<IAmACommunityMember> members)
        {
            _logger = logger;
            var random = new Random();
            _members = members.OrderBy(r => random.Next()).ToArray();
        }

        public IActionResult Index()
        {
            var viewModel = _members;
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            // TODO: Check if you want to use this or the older code below
            // return View(TempData["LastError"]);
        }
    }
}
