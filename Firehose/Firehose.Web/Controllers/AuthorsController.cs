using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Firehose.Web.Infrastructure;
using System.Reflection;

namespace Firehose.Web.Controllers
{
    public class AuthorsController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewModel = _members;
            return View(viewModel);
        }

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

        public AuthorsController(IEnumerable<IAmACommunityMember> members)
        {
            _members = GetAuthors();
            var random = new Random();
            _members = _members.OrderBy(r => random.Next()).ToArray();
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
    }
}