using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AMS.Web.UI.Models;

namespace AMS.Web.UI.Controllers.API
{
    public class ProductController : ApiController
    {



        private List<VmDashboard> products = new List<VmDashboard>();

        public ProductController()
        {
            products = InitlaizeProducts();
        }

         private List<VmDashboard> InitlaizeProducts()
        {
            List<VmDashboard> list = new List<VmDashboard>();
            list.Add(new VmDashboard { Id = 1, Name = "Television", Category = "Electronic", Price = 82000 });
            list.Add(new VmDashboard { Id = 2, Name = "Refrigerator", Category = "Electronic", Price = 23000 });
            list.Add(new VmDashboard { Id = 3, Name = "Mobiles", Category = "Electronic", Price = 20000 });
            list.Add(new VmDashboard { Id = 4, Name = "Laptops", Category = "Electronic", Price = 45000 });
            list.Add(new VmDashboard { Id = 5, Name = "iPads", Category = "Electronic", Price = 67000 });
            list.Add(new VmDashboard { Id = 6, Name = "Toys", Category = "Gift Items", Price = 15000 });
            return list;
        }

         /// <summary>
         /// URL:- http://localhost:1079/api/products/SelectAllProducts/
         /// </summary>
         /// <returns></returns>
         [HttpGet]
         public IEnumerable<VmDashboard> SelectAllProducts()
         {
             return products;
         }

        // GET api/product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/product/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IEnumerable<VmDashboard> Post(List<VmDashboard> product)
        {
            //***Write logic to Save Product in Database
            return product;
        }

        // PUT api/product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
        }
    }
}
