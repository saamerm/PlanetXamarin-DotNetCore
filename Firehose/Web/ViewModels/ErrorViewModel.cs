using System;
// TODO: Update this to .ViewModels, perhaps remove this class
namespace Firehose.Web.Models
{
  public class ErrorViewModel
  {
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
  }
}
