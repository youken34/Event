using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event.Models;
using System.Text.RegularExpressions;
using System;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;



namespace Event.Controllers;

public class CookiesController : Controller
{
    public void newConnectedCookies(Users newUser, HttpResponse response)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        if (newUser != null && response != null)
        {
            string user = JsonConvert.SerializeObject(newUser, settings);
            response.Cookies.Append("User", user, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(15),
                Domain = "localhost",
                Path = "/"
            });
        }

    }

    public void CheckConnectedCookies()
    {

    }

}