using Microsoft.AspNetCore.Mvc;
using CLVD6212_POE.Models;
using System;
using System.Collections.Generic;

namespace CLVD6212_POE.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Product()
        {
            var products = new List<Product>
            {
                new Product { Name = "Classic Tee", Description = "Simple yet stylish.", Price = 19.99M, ImageUrl = "~/images/classic-tee.jpg" },
                new Product { Name = "Denim Jacket", Description = "Perfect for any season.", Price = 49.99M, ImageUrl = "~/images/denim-jacket.jpg" }
                // Add more products here...
            };

            return View(products);
        }

        public IActionResult PrevOrders()
        {
            var orders = new List<Order>
            {
                new Order { OrderId = "12345", OrderDate = DateTime.Now.AddDays(-10), TotalAmount = 99.99M, Status = "Delivered" },
                new Order { OrderId = "12346", OrderDate = DateTime.Now.AddDays(-5), TotalAmount = 149.99M, Status = "Shipped" },
                new Order { OrderId = "12347", OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 199.99M, Status = "Processing" }
                // Add more orders here...
            };

            return View(orders);
        }
    }
}
