using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CNTT129.Models;
namespace CNTT129
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            HOATDONG hoatdong = new HOATDONG();
            hoatdong.khoaFormDangKyAll();
            hoatdong.khoaFormDiemDanhAll();

            DANGKY dangky = new DANGKY();
            dangky.capnhatKhongThamGia();

            HoatDongBuoi hdb = new HoatDongBuoi();
            hdb.updateTTHdb();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SinhVien", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}