using System;
using System.Collections.Generic;
using Firehose.Web.Infrastructure;

namespace Firehose.Web.Authors
{
  public class MarkAllibone : IAmAMicrosoftMVP
    {
        public string FirstName => "Mark";

        public string LastName => "Allibone";

        public string StateOrRegion => "Zurich, Switzerland";

        public string EmailAddress => "";

        public string ShortBioOrTagLine => "is a Microsoft MVP who blogs, talks, coaches and develops all around mobile development.";

        public Uri WebSite => new Uri("https://mallibone.com");

        public string TwitterHandle => "mallibone";

        public string GitHubHandle => "mallibone";

        public string GravatarHash => "4fa14971da4fafb96830960bc7c6733d";

        public IEnumerable<Uri> FeedUris => new List<Uri> {new Uri("https://mallibone.com/feed/") };

        public GeoPosition Position => new GeoPosition(47.5056381, 8.7241297);

        public string FeedLanguageCode => "en";
    }
}