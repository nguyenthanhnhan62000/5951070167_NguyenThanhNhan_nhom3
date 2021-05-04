using System.Web;
using System.Web.Mvc;

namespace _5951071067_NguyenThanhNhan_nhom3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
