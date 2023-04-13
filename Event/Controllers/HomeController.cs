using System.Diagnostics;
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
        List<Models.Event> recentEvents = Models.Event.RecentEvents();
        ViewBag.RecentEvents = recentEvents;
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
        String Email = Request.Form["Email"].ToString();
        String Password = Request.Form["Password"].ToString();
        if (!(String.IsNullOrEmpty(Email) &&
           String.IsNullOrEmpty(Password)))
        {
            if (EmailAndPasswordAlreadyTaken(Email, Password).Item1 == 1 && EmailAndPasswordAlreadyTaken(Email, Password).Item2 == 1)
            {
                Users userconnected = new Users(DatabaseController.FindUserID(Email, Password).GetUserID(), Email, Password);
                ViewBag.user = userconnected;
                List<Models.Event> recentEvents = Models.Event.RecentEvents();
                ViewBag.RecentEvents = recentEvents;
                return View("Index");
            }

        }

        return View("LogIn");
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
                if (EmailAndPasswordAlreadyTaken(Email, Password).Item1 == 0 && EmailAndPasswordAlreadyTaken(Email, Password).Item2 == 0)
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(Password);
                    byte[] hashedBytes = SHA256.Create().ComputeHash(passwordBytes);
                    string hashedPassword = Convert.ToBase64String(hashedBytes);
                    Users.Create(Email, hashedPassword);
                    Console.WriteLine("Account created successfully");
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
    public Tuple<int, int> EmailAndPasswordAlreadyTaken(String UserEmail, String UserPassword)
    {
        int countEmail = 0;
        int countPassword = 0;
        byte[] passwordBytes = Encoding.UTF8.GetBytes(UserPassword);
        byte[] hashedBytes = SHA256.Create().ComputeHash(passwordBytes);
        string hashedPassword = Convert.ToBase64String(hashedBytes);
        String queryMail = "Select * FROM Users WHERE UserEmail = @UserEmail ";
        String queryPassword = "Select * FROM Users WHERE UserPassword = @UserPassword";
        using (SqlConnection connection = new SqlConnection(DatabaseController.getconnexionString()))
        {
            connection.Open();
            using (SqlCommand commandEmail = new SqlCommand(queryMail, connection))
            using (SqlCommand commandPassword = new SqlCommand(queryPassword, connection))
            {
                commandEmail.Parameters.AddWithValue("@UserEmail", UserEmail);
                commandPassword.Parameters.AddWithValue("@UserPassword", hashedPassword);
                SqlDataReader data = commandEmail.ExecuteReader();
                if (data.HasRows)
                {
                    countEmail = 1;
                    Console.WriteLine("Email already taken");
                }
                data.Close();
                data = commandPassword.ExecuteReader();
                if (data.HasRows)
                {
                    countPassword = 1;
                    Console.WriteLine("Password already taken");
                }
                data.Close();
            }
        }
        return Tuple.Create(countEmail, countPassword);

    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
