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
    public IActionResult EventCreator(int eventid)
    {
        var cookie = Request.Cookies["User"];
        Users user = null;
        var isFollowing = false;
        Users creator = Event.Models.Event.UserCreator(eventid);
        if (cookie != null)
        {
            user = JsonConvert.DeserializeObject<Users>(cookie);
            isFollowing = Models.Followers.isFollowing(user.GetUserID(), creator.GetUserID());
        }
        ViewBag.isFollowing = isFollowing;
        ViewBag.creator = creator;
        return View();
    }
    public IActionResult Follow(int followerID, int followingID)
    {
        try
        {
            string query = "INSERT INTO FOLLOWERS (FollowerID, FollowingID) VALUES(@followerID, @followingID)";
            SqlCommand command = DatabaseController.OpenConnexion(query);
            command.Parameters.AddWithValue("@followerID", followerID);
            command.Parameters.AddWithValue("@followingID", followingID);
            command.ExecuteNonQuery();
            return RedirectToAction("EventCreator", new { eventid = Models.Event.MyEvents(followingID.ToString())[0].GetEventId() });
        }
        catch (Exception ex)
        {
            // Log the exception here
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
    public IActionResult Unfollow(int followerID, int followingID)
    {
        try
        {
            string query = "DELETE FROM FOLLOWERS WHERE FollowerID = @followerID AND followingID = @followingID";
            SqlCommand command = DatabaseController.OpenConnexion(query);
            command.Parameters.AddWithValue("@followerID", followerID);
            command.Parameters.AddWithValue("@followingID", followingID);
            command.ExecuteNonQuery();
            return RedirectToAction("EventCreator", new { eventid = Models.Event.MyEvents(followingID.ToString())[0].GetEventId() });
        }
        catch (Exception ex)
        {
            // Log the exception here
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

}