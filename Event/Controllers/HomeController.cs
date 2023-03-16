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
    public IActionResult Create(Event model)
{
    Console.WriteLine($"New event created: ");

    // retrieve the form data
    var title = Request.Form["Title"];
    var description = Request.Form["Description"];
    var category = Request.Form["Category"];
    var location = Request.Form["Location"];
    var dateEvent = DateTime.Parse(Request.Form["DateEvent"]);

    // create a new instance of the EventModel class
    var eventModel = new Event(title, description, category, location, dateEvent);
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
