using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ReactAPI.Models;

namespace ReactAPI.Controllers
{
    public class StockController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Stock> stocks = new List<Stock>()
            {
                new Stock{ ProductId=1, Qty=10 },
                new Stock{ ProductId=2, Qty=5 },
                new Stock{ ProductId=3, Qty=8 }
            };

            return Ok(stocks);
        }
    }
}
