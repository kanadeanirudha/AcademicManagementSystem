using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.Web.UI.Models
{
    public class VmDashboard
    {
        public int RateVisitors { get; set; }
        public int RatePageViews { get; set; }
        public int RateUsers { get; set; }

        public int RateOrders { get; set; }

        public List<Tuple<int, string, string, string>> Users;

        public List<Tuple<int, string, string, string>> Orders;

        public List<Tuple<int, string, string, string>> Clients;

        public List<Tuple<int, DateTime, Double>> Invoices;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}