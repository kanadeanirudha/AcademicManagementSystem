using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AMS.Web.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute("StudentList", "", new { controller = "FeeStructureApplicable", action = "GetStudentList" });
            routes.MapRoute("GetDepartmentByCentreCode",
                           "adminsnPosts/GetDepartmentByCentreCode/",
                           new { controller = "AdminSnPosts", action = "GetDepartmentByCentreCode" },
                           new[] { "AMS.Web.UI.Controllers" });

            routes.MapRoute("GetPostsByCentreCodeDepartmentID",
                           "adminRoleMaster/GetPostsByCentreCodeDepartmentID/",
                           new { controller = "AdminRoleMaster", action = "GetPostsByCentreCodeDepartmentID" },
                           new[] { "AMS.Web.UI.Controllers" });

            routes.MapRoute("GetDepartmentByCentreCodeForRoleMaster",
                         "AdminRoleMaster/GetDepartmentByCentreCodeForRoleMaster/",
                         new { controller = "AdminRoleMaster", action = "GetDepartmentByCentreCodeForRoleMaster" },
                         new[] { "AMS.Web.UI.Controllers" });

            routes.MapRoute("GetRegionByCountryID",
                          "GeneralLocationMaster/GetRegionByCountryID/",
                          new { controller = "GeneralLocationMaster", action = "GetRegionByCountryID" },
                          new[] { "AMS.Web.UI.Controllers" });

            routes.MapRoute("GetCityByRegionID",
                         "GeneralLocationMaster/GetCityByRegionID/",
                         new { controller = "GeneralLocationMaster", action = "GetCityByRegionID" },
                         new[] { "AMS.Web.UI.Controllers" });

            routes.MapRoute("GetStudyCentreHORO",
                        "OrganisationStudyCentreMaster/GetStudyCentreHORO/",
                        new { controller = "OrganisationStudyCentreMaster", action = "GetStudyCentreHORO" },
                        new[] { "AMS.Web.UI.Controllers" });
        }
    }
}