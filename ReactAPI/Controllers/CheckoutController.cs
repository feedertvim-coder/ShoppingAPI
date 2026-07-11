using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReactAPI.Models;
using ReactAPI.App_Data;
using System.Linq;
namespace ReactAPI.Controllers
{
    public class CheckoutController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post()
        {
            decimal total = 0;

            foreach (var cart in MockData.CartItems)
            {
                var stock = MockData.Stocks
                    .FirstOrDefault(x => x.ProductId == cart.ProductId);

                if (stock == null)
                    return BadRequest("Stock not found");

                if (stock.Qty < cart.Qty)
                    return BadRequest("Stock not enough");

                stock.Qty -= cart.Qty;

                total += cart.Qty * cart.UnitPrice;
            }

            MockData.CartItems.Clear();

            return Ok(new
            {
                Message = "Checkout Success",
                Total = total
            });
        }
    }
    }
 
