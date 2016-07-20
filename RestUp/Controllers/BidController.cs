using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestUp.Controllers
{
    public class BidController : ApiController
    {
        // GET: api/Bid
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Bid/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bid
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bid/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bid/5
        public void Delete(int id)
        {
        }
    }
}
