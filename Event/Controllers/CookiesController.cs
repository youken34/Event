using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event.Models;
using System.Text.RegularExpressions;
using System;
using System.Web;
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
        Response.Cookies.Append("myCookie", "valeur de cookie", new CookieOptions
        {
            Expires = DateTimeOffset.Now.AddDays(1)
        });
    }
}