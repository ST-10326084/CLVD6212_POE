using CLVD6212_POE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace CLVD6212_POE.Controllers
{
    public class AccountController : Controller
    {
        // Login view
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Hardcoded validation logic
                bool isValidUser = (model.Username == "admin" && model.Password == "password");

                if (isValidUser)
                {
                    // Handle successful login (redirect to home page)
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

        // Signup view
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(SignupViewModel model)
        {
            ViewBag.FormSubmitted = false; // Initialize it to a default value

            if (ModelState.IsValid)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    // Handle successful signup logic (e.g., store user data)
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
            // Profile page
        public IActionResult Profile()
            {
                bool isLoggedIn = CheckIfUserIsLoggedIn();
                ViewBag.IsLoggedIn = isLoggedIn;
                return View();
            }

            private bool CheckIfUserIsLoggedIn()
            {
                // Simulate a user authentication check
                // Replace this with actual authentication logic
                return false; // Set to true if the user is logged in
            }

            
        }
    }


