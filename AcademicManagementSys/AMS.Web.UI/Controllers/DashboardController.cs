using AMS.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMS.Web.UI.Controllers
{
    public class DashboardController : BaseController
    {
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            //VmDashboard dummyData = getDummyData();
            return PartialView("JobOrderGraph");
        }
        public ActionResult JobOrderTable()
        {
            //VmDashboard dummyData = getDummyData();
            return PartialView("JobOrderTable");
        }
        public ActionResult InsuranceGraph()
        {
            //VmDashboard dummyData = getDummyData();
            return PartialView("InsuranceGraph");
        }

        public ActionResult InsuranceTable()
        {
            //VmDashboard dummyData = getDummyData();
            return PartialView("Insurance");
        }
     
        public ActionResult JobOrderEmployeePerfomance()
        {
            //VmDashboard dummyData = getDummyData();
            return PartialView("JobOrderEmployeePerfomance");
        }
        public ActionResult JobOrderEmployeePerfomanceGraph()
        {
            //VmDashboard dummyData = getDummyData();
            return PartialView("JobOrderEmployeePerfomanceGraph");
        }
        public ActionResult InsuranceDelhi()
        {
            //VmDashboard dummyData = getDummyData();
            return PartialView("InsuranceDelhi");
        }
        public ActionResult InsuranceMumbai()
        {
            //VmDashboard dummyData = getDummyData();
            return PartialView("InsuranceMumbai");
        }
        public ActionResult InsuranceBranchAll()
        {
            //VmDashboard dummyData = getDummyData();
            return PartialView("InsuranceBranchAll");
        }
        //private VmDashboard getDummyData()
        //{
        //    VmDashboard data = new VmDashboard();
        //    data.RateVisitors = 73;
        //    data.RateUsers = 52;
        //    data.RateOrders = 78;
        //    data.RatePageViews = 42;

        //    data.Clients = new List<Tuple<int, string, string, string>>();
        //    data.Clients.Add(new Tuple<int, string, string, string>(1, "Mark", "Otto", "@mdo"));
        //    data.Clients.Add(new Tuple<int, string, string, string>(2, "Jacob", "Thornton", "@fat"));
        //    data.Clients.Add(new Tuple<int, string, string, string>(3, "Vincent", "Gabriel", "@gabrielva"));

        //    data.Invoices = new List<Tuple<int, DateTime, double>>();
        //    data.Invoices.Add(new Tuple<int, DateTime, double>(1, new DateTime(2013, 2, 2), 25.12));
        //    data.Invoices.Add(new Tuple<int, DateTime, double>(2, new DateTime(2013, 2, 1),335.00));
        //    data.Invoices.Add(new Tuple<int, DateTime, double>(3, new DateTime(2013, 2, 1), 29.99));

        //    data.Orders = new List<Tuple<int, string, string, string>>();
        //    data.Orders.Add(new Tuple<int, string, string, string>(1, "Coat", "02/02/2013", "$25.12"));
        //    data.Orders.Add(new Tuple<int, string, string, string>(2, "Jacket", "01/02/2013", "$335.00"));
        //    data.Orders.Add(new Tuple<int, string, string, string>(3, "Shoes", "01/02/2013", "$29.99"));

        //    data.Users = new List<Tuple<int, string, string, string>>();
        //    data.Users.Add(new Tuple<int, string, string, string>(1, "Mark", "Otto", "@mdo"));
        //    data.Users.Add(new Tuple<int, string, string, string>(2, "Jacob", "Thornton", "@fat"));
        //    data.Users.Add(new Tuple<int, string, string, string>(3, "Vincent", "Gabriel", "@gabrielva"));

        //    return data;
        //}
    }
}