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
    public class ProductController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {

            var data =
                MockData.Products.Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.Price,

                    Qty =
                    MockData.Stocks
                    .Where(s => s.ProductId == p.ProductId)
                    .Select(s => s.Qty)
                    .FirstOrDefault()

                });


            return Ok(data);


            //return Ok(MockData.Products);
        }
    }
}
