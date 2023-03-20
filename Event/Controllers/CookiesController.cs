using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event.Models;
using System.Text.RegularExpressions;
using System;
using System.Web
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using Event.Models;
using Microsoft.AspNetCore.Http;



namespace Event.Controllers;

public class CookiesController : Controller
{
    public void newConnectedCookies()
    {
        HttpCookie cookie = new HttpCookie("myCookie"); // Create a new cookie object with the name "myCookie"
        cookie.Value = value.ToString(); // Set the value of the cookie to the string representation of the bool value
        cookie.Expires = DateTime.Now.AddDays(1); // Set the cookie to expire in 1 day
        Response.Cookies.Add(cookie);
    }
}