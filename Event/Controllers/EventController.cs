using Microsoft.AspNetCore.Mvc;
using Event.Models;
using System;
using System.Text;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Event.Controllers;


public class EventController : Controller
{
    public IActionResult Index(int id)
    {
        Event.Models.Event eventdetails = Event.Models.Event.EventDetails(id);
        ViewBag.Eventdetails = eventdetails;
        return View();
    }
    public IActionResult MyEvents()
    {
        List<Event.Models.Event> myEvents = new List<Event.Models.Event>();
        var cookie = Request.Cookies["User"];
        Users user = JsonConvert.DeserializeObject<Users>(cookie);
        Console.WriteLine(user.GetUserID());
        myEvents = Event.Models.Event.MyEvents(user.GetUserID().ToString());
        ViewBag.MyEvents = myEvents;
        return View();
    }

}