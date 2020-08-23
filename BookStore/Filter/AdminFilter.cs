using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Filter
{
    public class AdminFilter : ActionFilterAttribute
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
            else
            {
                var userLevel = Int32.Parse(session["UserLevel"].ToString());
                if (userLevel == 1)
                {
                    controller.HttpContext.Response.Redirect("/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}