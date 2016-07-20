using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestUp.Controllers
{
    public class BasketItemController : ApiController
    {
        // GET: api/BasketItem
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BasketItem/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BasketItem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BasketItem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BasketItem/5
        public void Delete(int id)
        {
        }
    }
}
