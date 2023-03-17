using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event.Models;

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
            Event.InsertEvent(title, description, category, location, dateEvent);
        }
        return View("ListEvent");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
