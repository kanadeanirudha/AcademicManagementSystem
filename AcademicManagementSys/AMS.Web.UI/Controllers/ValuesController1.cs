using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.Web.UI.Controllers
{
   
    public class ValuesController1 : ApiController
    {
        //    // GET api/<controller>
        //    public IEnumerable<string> Get()
        //    {
        //        return new string[] { "value1", "value2" };
        //    }

        //    // GET api/<controller>/5
        //    public string Get(int id)
        //    {
        //        return "value";
        //    }

        //    // POST api/<controller>
        //    public void Post([FromBody]string value)
        //    {
        //    }

        //    // PUT api/<controller>/5
        //    public void Put(int id, [FromBody]string value)
        //    {
        //    }

        //    // DELETE api/<controller>/5
        //    public void Delete(int id)
        //    {
        //    }
        // POST api/<controller>
        public HttpResponseMessage Post(HttpRequestMessage value)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("I'll be running on an Azure Web Site!");
            return response;
        }

        public HttpResponseMessage Get()
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("I'll be running on an Azure Web Site!");
            return response;
        }
    }


}