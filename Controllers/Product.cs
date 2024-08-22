using Microsoft.AspNetCore.Mvc;

namespace CLVD6212_POE.Controllers
{
    public class Product : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            var products = new List<Product>
    {
        new Product { Name = "Classic Tee", Description = "Simple yet stylish.", Price = 19.99M, ImageUrl = "~/images/classic-tee.jpg" },
        new Product { Name = "Denim Jacket", Description = "Perfect for any season.", Price = 49.99M, ImageUrl = "~/images/denim-jacket.jpg" },
        // Add more products here...
    };

            return View(products);
        }

        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
        }

    }
}
