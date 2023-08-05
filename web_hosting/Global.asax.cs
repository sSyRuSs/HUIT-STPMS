using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CNTT129
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Session_Start()
        {
            Session["log_gv"] = false;
            Session["logsv"] = false;
            Session["Ten_gv"] = "";
            Session["ma_gv"] = "";
            Session["id_gv"] = "";
            Session["ma_qr"] = "";
            Session["Ten_sv"] = "";
            Session["ma_sv"] = "";
            Session["id_sv"] = "";
            Session["link_qr"] = "";
            Session["name_vt"] = "";
        }
    }
}