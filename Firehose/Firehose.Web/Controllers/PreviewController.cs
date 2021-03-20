using System.Globalization;
using System.Linq;
using System.ServiceModel.Syndication;
using Microsoft.AspNetCore.Mvc;
using Firehose.Web.Infrastructure;
using Firehose.Web.ViewModels;

namespace Firehose.Web.Controllers
{
    public class PreviewController : BaseController
    {
        private readonly NewCombinedFeedSource _combinedFeedSource;

        public PreviewController(NewCombinedFeedSource combinedFeedSource)
        {
            _combinedFeedSource = combinedFeedSource;
        }

        public IActionResult Index()
        {
            var feed = GetFeed();
            return View(new PreviewViewModel(feed, _combinedFeedSource.Tamarins.ToArray()));
        }

        private SyndicationFeed GetFeed()
        {
			var lang = CultureInfo.CreateSpecificCulture("en").Name;
			var feed = _combinedFeedSource.LoadFeed(50, lang).GetAwaiter().GetResult();
            return feed;
        }
    }
}