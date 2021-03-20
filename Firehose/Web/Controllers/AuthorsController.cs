using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Firehose.Web.Infrastructure;

namespace Firehose.Web.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewModel = _members;
            return View(viewModel);
        }

        private readonly IAmACommunityMember[] _members;

        public AuthorsController(IEnumerable<IAmACommunityMember> members)
        {
            var random = new Random();
            _members = members.OrderBy(r => random.Next()).ToArray();
        }
    }
}