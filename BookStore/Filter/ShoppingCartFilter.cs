using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Filter
{
    public class ShoppingCartFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;
            var i = controller.ControllerContext.RouteData;
            if(session["shoppingCart"] == null)
            {
                session["shoppingCart"] = new ShoppingCart();
            }
            base.OnActionExecuted(filterContext);
        }
    }
}