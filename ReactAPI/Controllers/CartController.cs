using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReactAPI.Models;
namespace ReactAPI.Controllers
{
    public class CartController : ApiController
    {
        static List<Cart> carts = new List<Cart>()
        {
            new Cart
            {
                CartId=1,
                Status="OPEN"
            }
        };

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(carts);
        }

        [HttpPost]
        public IHttpActionResult Post(Cart cart)
        {
            carts.Add(cart);
            return Ok(cart);
        }
    }
}
