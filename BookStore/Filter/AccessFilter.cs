using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Filter
{
    public class AccessFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;
            var userId = session["UserId"];
            if (userId == null)
            {
                controller.HttpContext.Response.Redirect("/Login/SignIn");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}