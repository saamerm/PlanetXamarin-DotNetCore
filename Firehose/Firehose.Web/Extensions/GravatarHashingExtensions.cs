using Firehose.Web.Infrastructure;
using System.Configuration;
using System.Net;

namespace Firehose.Web.Extensions
{
    public static class GravatarHashingExtensions
    {
        public static string GravatarImage(this IAmACommunityMember member)
        {
            const int size = 200;
            var hash = member.GravatarHash;

            if (string.IsNullOrWhiteSpace(hash))
                hash = member.EmailAddress.Trim().ToLowerInvariant().ToMd5Hash().ToLowerInvariant();

            var defaultImage = WebUtility.UrlEncode(ConfigurationManager.AppSettings["DefaultGravatarImage"]);
            return $"//www.gravatar.com/avatar/{hash}.jpg?s={size}&d={defaultImage}";
        }
    }
}