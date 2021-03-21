using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Firehose.Web.Models;
using Firehose.Web.Infrastructure;
using System.Reflection;

namespace Firehose.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEnumerable<IAmACommunityMember> _members;
        private string[] _interfaceNames =
		{
			nameof(IAmACommunityMember),
			nameof(IWorkAtXamarinOrMicrosoft),
			nameof(IAmAXamarinMVP),
			nameof(IAmAMicrosoftMVP),
			nameof(IAmAPodcast),
			nameof(IAmANewsletter),
			nameof(IAmAFrameworkForXamarin),
			nameof(IAmAYoutuber)
		};

        public HomeController(ILogger<HomeController> logger, IEnumerable<IAmACommunityMember> members)
        {
            _logger = logger;
            _members = GetAuthors();
        }

        private IEnumerable<IAmACommunityMember> GetAuthors()
        {
            var assembly = Assembly.GetAssembly(typeof(IAmACommunityMember));

            var types = assembly.GetTypes();
            var authorTypes = types.Where(t => typeof(IAmACommunityMember).IsAssignableFrom(t) &&
                !_interfaceNames.Contains(t.Name));

            foreach (var authorType in authorTypes)
            {
                var author = (IAmACommunityMember)Activator.CreateInstance(authorType);
                yield return author;
            }
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
