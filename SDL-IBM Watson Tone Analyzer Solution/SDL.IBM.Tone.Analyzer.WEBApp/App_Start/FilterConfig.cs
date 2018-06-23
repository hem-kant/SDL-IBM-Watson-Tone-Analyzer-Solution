using System.Web;
using System.Web.Mvc;

namespace SDL.IBM.Tone.Analyzer.WEBApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
