using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReactAPI.Models;
namespace ReactAPI.App_Data
{
    public static class MockData
    {
        //public static List<Product> Products = new List<Product>()
        //{
        //    new Product { ProductId=1, ProductName="iPhone 16", Price=35900 },
        //    new Product { ProductId=2, ProductName="Samsung S25", Price=29900 },
        //    new Product { ProductId=3, ProductName="iPad Air", Price=24900 }
        //};

        public static List<Product> Products =
    new List<Product>()
{
            new Product
            {
                ProductId=1,
                ProductName="iPhone 16",
                Price=35900
            },

            new Product
            {
                ProductId=2,
                ProductName="Samsung S25",
                Price=29900
            },

            new Product
            {
                ProductId=3,
                ProductName="iPad Air",
                Price=24900
            }
};

        //public static List<Stock> Stocks = new List<Stock>()
        //{
        //    new Stock { ProductId=1, Qty=10 },
        //    new Stock { ProductId=2, Qty=5 },
        //    new Stock { ProductId=3, Qty=8 }
        //};

        //public static List<Cart> Carts = new List<Cart>()
        //{
        //    new Cart { CartId=1, Status="OPEN" }
        //};

        public static List<Stock> Stocks =
            new List<Stock>()
        {
            new Stock
            {
                ProductId=1,
                Qty=10
            },

            new Stock
            {
                ProductId=2,
                Qty=5
            },

            new Stock
            {
                ProductId=3,
                Qty=8
            }
        };

        public static List<CartItem> CartItems = new List<CartItem>();
    }
}