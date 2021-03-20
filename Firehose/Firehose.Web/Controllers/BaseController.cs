using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Firehose.Web.Controllers
{
    public class BaseController : Controller
    {
        // TODO: Fix this, it's supposed to be protected void OnException(ExceptionContext filterContext)
        // but OnException is not available
        protected void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                // Get the exception.
                var e = filterContext.Exception;

                // Mark exception as handled
                filterContext.ExceptionHandled = true;

                TempData["LastError"] = e;

                // Redirect to our error provider.
                filterContext.Result = RedirectToAction("Error", "Home");
            }
        }
    }
}
