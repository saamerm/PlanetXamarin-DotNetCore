using Firehose.Web.Infrastructure;
using System.Configuration;
using System.Web;
using System.Security.Cryptography;
using System.Text;

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

      var defaultImage = HttpUtility.UrlEncode(ConfigurationManager.AppSettings["DefaultGravatarImage"]);
      return $"//www.gravatar.com/avatar/{hash}.jpg?s={size}&d={defaultImage}";
    }

    public static string ToMd5Hash(this string input)
    {
      var hash = new StringBuilder();
      MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
      byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

      for (int i = 0; i < bytes.Length; i++)
      {
        hash.Append(bytes[i].ToString("x2"));
      }
      return hash.ToString();
    }
  }
}