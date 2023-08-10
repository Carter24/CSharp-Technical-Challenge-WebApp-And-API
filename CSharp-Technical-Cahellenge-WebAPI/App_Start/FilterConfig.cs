using System.Web;
using System.Web.Mvc;

namespace CSharp_Technical_Cahellenge_WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
