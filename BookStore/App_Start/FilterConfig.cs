using BookStore.Filter;
using System.Web;
using System.Web.Mvc;

namespace BookStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            GlobalFilters.Filters.Add(new ShoppingCartFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
