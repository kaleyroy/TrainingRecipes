using System.Web;
using System.Web.Mvc;

namespace EF5Repository.Mvc4App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}