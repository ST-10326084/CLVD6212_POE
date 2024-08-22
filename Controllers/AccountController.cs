using CLVD6212_POE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD6212_POE.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Validate the user's credentials
                // Implement your authentication logic here

                // Example validation logic
                bool isValidUser = (model.Username == "admin" && model.Password == "password"); // Replace with real validation

                if (isValidUser)
                {
                    // Handle successful login (e.g., setting authentication cookie, redirecting)
                    return RedirectToAction("Index", "Home"); // Redirect to the home page or another page
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed; redisplay form
            return View(model);
        }


        public ActionResult PreviousOrders()
        {
            // Simulate loading data (replace with actual database call)
            var orders = new List<Order>
    {
        new Order { OrderId = "12345", OrderDate = DateTime.Now.AddDays(-10), TotalAmount = 99.99m, Status = "Delivered" },
        new Order { OrderId = "12346", OrderDate = DateTime.Now.AddDays(-5), TotalAmount = 149.99m, Status = "Shipped" },
        new Order { OrderId = "12347", OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 199.99m, Status = "Processing" }
    };

            return View(orders);
        }

        public class Order
        {
            public string OrderId { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal TotalAmount { get; set; }
            public string Status { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    // Handle successful signup logic here (e.g., saving to a database)
                    ViewBag.FormSubmitted = true;
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "Passwords do not match.");
                }
            }

            return View(model);
        }

    }
}
