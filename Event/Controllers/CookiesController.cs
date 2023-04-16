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
using Newtonsoft.Json;



namespace Event.Controllers;

public class CookiesController : Controller
{
    public void newConnectedCookies(Users newUser)
    {
        if (newUser != null)
        {
            string user = JsonConvert.SerializeObject(newUser);

            Response.Cookies.Append("User", user, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(1),
                Domain = "localhost",
                Path = "/"
            });
        }

    }

    public void CheckConnectedCookies()
    {

    }

}