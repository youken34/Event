﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event.Models;
using System.Text.RegularExpressions;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;


namespace Event.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ListEvent()
    {
        return View();
    }
    public IActionResult LogIn()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Connexion()
    {
        if (!(String.IsNullOrEmpty(Request.Form["Email"]) ||
           String.IsNullOrEmpty(Request.Form["Password"])))
        {

        }
        return View("Home");
    }

    [HttpPost]
    public IActionResult NewUser()
    {
        if (!(String.IsNullOrEmpty(Request.Form["Email"]) ||
           String.IsNullOrEmpty(Request.Form["Password"])))
        {
            var Email = Request.Form["Email"].ToString();
            var Password = Request.Form["Password"].ToString();
            bool containsLowercase = Regex.IsMatch(Password, "[a-z]");
            bool containsUppercase = Regex.IsMatch(Password, "[A-Z]");
            bool containsSpecialChar = Regex.IsMatch(Password, @"[^a-zA-Z0-9]");
            if (containsLowercase && containsUppercase && containsSpecialChar && Password.Length > 8)
            {
                if (EmailAndPasswordAlreadyTaken(Email, Password))
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(Password);
                    byte[] hashedBytes = SHA256.Create().ComputeHash(passwordBytes);
                    string hashedPassword = Convert.ToBase64String(hashedBytes);
                    Users.Create(Email, hashedPassword);
                    Console.WriteLine("Account created successfully");
                }
                else
                {
                    Console.WriteLine("Email and / or Password already taken");
                }
            }
            else
            {
                Console.WriteLine("Password must contains at least 8 characters one upper and lower character, one number and one special character");
            }
        }
        else
        {
            Console.WriteLine("Fields are empty");
        }
        return View("SignUp");
    }
    [HttpPost]
    public IActionResult Create()
    {
        // create a new instance of the EventModel class
        if (!(String.IsNullOrEmpty(Request.Form["Title"]) ||
            String.IsNullOrEmpty(Request.Form["Description"]) ||
            String.IsNullOrEmpty(Request.Form["Category"]) ||
            String.IsNullOrEmpty(Request.Form["Location"]) ||
            Request.Form["DateEvent"].GetType() == typeof(DateTime)))
        {
            // retrieve the form data
            var title = Request.Form["Title"].ToString();
            var description = Request.Form["Description"].ToString();
            var category = Request.Form["Category"].ToString();
            var location = Request.Form["Location"].ToString();
            var dateEvent = DateTime.Parse(Request.Form["DateEvent"]);
            Event.Models.Event.InsertEvent(title, description, category, location, dateEvent);
        }
        return View("ListEvent");
    }
    [HttpPost]
    public bool EmailAndPasswordAlreadyTaken(String UserEmail, String UserPassword)
    {

        String queryMail = "Select COUNT(*) FROM Users WHERE UserEmail = @UserEmail ";
        String queryPassword = "Select COUNT(*) FROM Users WHERE UserPassword = @UserPassword";
        using (SqlConnection connection = new SqlConnection(DatabaseController.getconnexionString()))
        {
            connection.Open();
            using (SqlCommand commandEmail = new SqlCommand(queryMail, connection))
            using (SqlCommand commandPassword = new SqlCommand(queryPassword, connection))
            {
                commandEmail.Parameters.AddWithValue("@UserEmail", UserEmail);
                commandPassword.Parameters.AddWithValue("@UserPassword", UserPassword);

                int countEmail = (int)commandEmail.ExecuteScalar();
                int countPassword = (int)commandPassword.ExecuteScalar();
                if (countEmail != 0)
                {
                    Console.WriteLine("Email already taken");
                    return false;
                }
                else
                {
                    if (countPassword != 0)
                    {
                        Console.WriteLine("Password already taken");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
            }
        }



    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
