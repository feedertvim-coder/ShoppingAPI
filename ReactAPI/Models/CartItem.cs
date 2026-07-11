using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReactAPI.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
    }
}