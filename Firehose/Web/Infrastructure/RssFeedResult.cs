using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.AspNetCore.Mvc;

namespace Firehose.Web.Infrastructure
{
	public class RssFeedResult : ActionResult
	{
		private readonly SyndicationFeed _feed;

		public RssFeedResult(SyndicationFeed feed)
		{
			_feed = feed;
		}

		public override void ExecuteResult(ActionContext context)
		{
			context.HttpContext.Response.ContentType = "application/rss+xml";

			var rssFormatter = new Rss20FeedFormatter(_feed);

			// TODO: Verify it should be Body, because it is currently 			using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
			// but HttpContext.Response.Output isn't accessible  anymore
			using (var writer = XmlWriter.Create(context.HttpContext.Response.Body))
			{
				rssFormatter.WriteTo(writer);
			}
		}
	}
}
