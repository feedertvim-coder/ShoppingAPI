using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReactAPI.Models;
using ReactAPI.App_Data;

namespace ReactAPI.Controllers
{
    [RoutePrefix("api/cartitem")]
    public class CartItemController : ApiController
        {

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(MockData.CartItems);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var item = MockData.CartItems
                .FirstOrDefault(x => x.CartItemId == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(CartItem item)
            {
            var stock =
           MockData.Stocks
           .FirstOrDefault(x =>
            x.ProductId == item.ProductId);

            if (stock == null)
                return BadRequest("Product not found");

            if (stock.Qty < item.Qty)
                return BadRequest("Stock not enough");

            // ตัด Stock
            stock.Qty -= item.Qty;

            var product =
            MockData.Products
            .First(x =>
                x.ProductId == item.ProductId);

            item.CartItemId =
                MockData.CartItems.Count == 0
                ? 1
                : MockData.CartItems.Max(x => x.CartItemId) + 1;

            item.UnitPrice =
            product.Price;

            MockData.CartItems.Add(item);

            return Ok(MockData.CartItems);

            //var oldItem =
            //MockData.CartItems
            //.FirstOrDefault(x =>
            //x.ProductId == item.ProductId);



            //int currentQty = 0;


            //if (oldItem != null)
            //    currentQty = oldItem.Qty;



            //if (stock.Qty < currentQty + item.Qty)
            //{
            //    return BadRequest(
            //    "Stock not enough");
            //}



            //if (oldItem != null)
            //{
            //    oldItem.Qty += item.Qty;
            //}
            //else
            //{
            //    item.CartItemId =
            //    MockData.CartItems.Count + 1;


            //    var product =
            //    MockData.Products
            //    .First(x =>
            //    x.ProductId ==
            //    item.ProductId);



            //    item.UnitPrice =
            //    product.Price;


            //    MockData.CartItems.Add(item);
            //}



            //return Ok(MockData.CartItems);

        }

        // DELETE /api/cartitem/{id}
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            //var item =
            //MockData.CartItems
            //.FirstOrDefault(x =>
            //x.CartItemId == id);


            //if (item == null)
            //    return NotFound();


            //MockData.CartItems.Remove(item);


            //return Ok();
            var cart =
              MockData.CartItems
              .FirstOrDefault(x =>
                  x.CartItemId == id);


            if (cart == null)
                return NotFound();


            var stock =
                MockData.Stocks
                .First(x =>
                    x.ProductId == cart.ProductId);


            stock.Qty += cart.Qty;


            MockData.CartItems.Remove(cart);


            return Ok(new
            {
                Message = "Delete success"
            });
        }


        [HttpDelete]
        [Route("")]
        public IHttpActionResult Clear()
        {

            foreach (var item in MockData.CartItems)
            {

                var stock =
                MockData.Stocks
                .First(x =>
                x.ProductId == item.ProductId);


                stock.Qty += item.Qty;

            }


            MockData.CartItems.Clear();


            return Ok(
                new
                {
                    Message = "Clear cart success"
                }
            );

        }




        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(CartItem item)
        {

            var cart =
            MockData.CartItems
            .FirstOrDefault(x =>
                x.CartItemId == item.CartItemId);

            if (cart == null)
            {
                return NotFound();
            }

            var stock =
            MockData.Stocks
            .FirstOrDefault(x =>
                x.ProductId == cart.ProductId);

            if (stock == null)
            {
                return BadRequest("Stock not found");
            }

            int diff = item.Qty - cart.Qty;


            if (stock.Qty < diff)
                return BadRequest("Stock not enough");


            stock.Qty -= diff;


            cart.Qty = item.Qty;


            //return Ok(cart);
            return Ok("PUT WORK");
        }
    }
}
 
