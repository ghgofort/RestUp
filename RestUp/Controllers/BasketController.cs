using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices;
using BusinessEntities;

namespace RestUp.Controllers
{
    public class BasketController : ApiController
    {
        #region Public Constructor
        /// <summary>
        /// Public constructor to create an instance of our product service
        /// </summary>
        public BasketController(IBasketServices basketServices)
        {
            _basketServices = basketServices;
        }
        #endregion

        private readonly IBasketServices _basketServices;
        
        // GET: api/Basket
        public HttpResponseMessage Get()
        {
            var baskets = _basketServices.GetBasketList();
            if(baskets != null)
            {
                var basketEntities = baskets as List<BasketEntity> ?? baskets.ToList();
                if(basketEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, basketEntities);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Baskets Found");
        }

        // GET: api/Basket/5
        public HttpResponseMessage Get(int id)
        {
            var basket = _basketServices.GetBasketById(id);
            if (basket != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, basket);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No basket found for this id");
        }

        // POST: api/Basket
        public int Post([FromBody]BasketEntity basketEntity)
        {
            return _basketServices.CreateBasket(basketEntity);
        }

        // PUT: api/Basket/5
        public bool Put(int id, [FromBody]BasketEntity basketEntity)
        {
            if(id>0)
            {
                return _basketServices.UpdateBasket(id, basketEntity);
            }
            return false;
        }

        // DELETE: api/Basket/5
        public bool Delete(int id)
        {
            if(id>0)
            {
                return _basketServices.DeleteBasket(id);
            }
            return false;
        }
    }
}
