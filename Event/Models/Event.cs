using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using Event.Controllers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Globalization;

namespace Event.Models;
public class Event
{
    private int EventId { get; set; }
    private string Title { get; set; }
    private string Description { get; set; }
    public enum TypeofCategory
    {
        Festival,
        Tournament,
        Party,
        Conference,
        Expo
    }
    private TypeofCategory Category { get; set; }
    private string Location { get; set; }
    private DateTime DateEvent { get; set; }
    public Event()
    {

    }

    public int GetEventId()
    {
        return EventId;
    }

    public string GetTitle()
    {
        return Title;
    }
    public string GetDescription()
    {
        return Description;
    }
    public string GetCategory()
    {
        return Category.ToString();
    }
    public string GetLocation()
    {
        return Location;
    }

    public DateTime GetDate()
    {
        return DateEvent;
    }


    public void SetEventId(int eventId)
    {
        EventId = eventId;
    }

    public void SetTitle(string title)
    {
        Title = title;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetCategory(TypeofCategory category)
    {
        Category = category;
    }

    public void SetLocation(string location)
    {
        Location = location;
    }

    public void SetDate(DateTime date)
    {
        DateEvent = date;
    }

    public static Event EventDetails(int EventID)
    {
        Event eventdetails = new Event();
        String query = "SELECT * FROM EVENT WHERE EventID = @EventID";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@EventID", EventID);
        SqlDataReader data = command.ExecuteReader();
        if (data.HasRows)
        {
            data.Read();
            eventdetails.EventId = Convert.ToInt32(data["EventID"]);
            eventdetails.Title = data["Title"].ToString();
            eventdetails.Description = data["Description"].ToString();
            eventdetails.Location = data["Location"].ToString();
            eventdetails.DateEvent = Convert.ToDateTime(data["DateEvent"]);
            string categoryString = data["Category"].ToString();

            if (Enum.TryParse(categoryString, out TypeofCategory category))
            {
                eventdetails.Category = category;

            }
        }
        data.Close();
        command.Dispose();
        return eventdetails;
    }
    public static void InsertEvent(string Title, string Description, string Category, string Location, DateTime DateEvent, int UserID)
    {
        String query = "INSERT INTO Event (Title, Description, Category, Location, DateEvent, UserID) VALUES(@Title, @Description, @Category, @Location, CONVERT(DATETIME, @DateEvent,  101), @UserID)";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@Title", Title);
        command.Parameters.AddWithValue("@Description", Description);
        command.Parameters.AddWithValue("@Category", Category);
        command.Parameters.AddWithValue("@Location", Location);
        command.Parameters.AddWithValue("@DateEvent", DateEvent.ToString("MMM dd yyyy h:mmtt", CultureInfo.InvariantCulture));
        command.Parameters.AddWithValue("@UserID", UserID);
        command.ExecuteNonQuery();
        command.Dispose();
    }
    public static List<Event> MyEvents(string UserID)
    {
        List<Event> myevents = new List<Event>();
        String query = "SELECT * FROM EVENT WHERE UserID = @UserID";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@UserID", UserID);
        SqlDataReader data = command.ExecuteReader();
        if (data.HasRows)
        {
            while (data.Read())
            {
                Event eventItem = new Event();
                eventItem.EventId = Convert.ToInt32(data["EventID"]);
                eventItem.Title = data["Title"].ToString();
                eventItem.Description = data["Description"].ToString();
                eventItem.Location = data["Location"].ToString();
                eventItem.DateEvent = Convert.ToDateTime(data["DateEvent"]);
                string categoryString = data["Category"].ToString();
                if (Enum.TryParse(categoryString, out TypeofCategory category))
                {
                    eventItem.Category = category;

                }
                myevents.Add(eventItem);
            }
        }
        data.Close();
        command.Dispose();
        return myevents;
    }
    static public List<Event> RecentEvents()
    {
        List<Event> recentEvent = new List<Event>();
        String query = "SELECT * FROM EVENT WHERE DateEvent >= GETDATE()";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        SqlDataReader data = command.ExecuteReader();
        if (data.HasRows)
        {
            while (data.Read())
            {
                Event eventItem = new Event();
                eventItem.EventId = Convert.ToInt32(data["EventID"]);
                eventItem.Title = data["Title"].ToString();
                eventItem.Description = data["Description"].ToString();
                eventItem.Location = data["Location"].ToString();
                eventItem.DateEvent = Convert.ToDateTime(data["DateEvent"]);
                string categoryString = data["Category"].ToString();

                if (Enum.TryParse(categoryString, out TypeofCategory category))
                {
                    eventItem.Category = category;

                }
                recentEvent.Add(eventItem);
            }
        }

        data.Close();
        command.Dispose();
        DatabaseController.OpenConnexion(query).Connection.Close();
        return recentEvent;
    }
    static public Users UserCreator(int eventId)
    {
        Users creator = new Users();
        string query = "SELECT u.UserEmail, u.UserName, u.Eventposted, u.Followers, u.UserID FROM Event e INNER JOIN Users u ON u.UserID = e.UserID WHERE e.EventID = @eventID";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@eventID", eventId);
        SqlDataReader data = command.ExecuteReader();
        if (data.HasRows)
        {
            while (data.Read())
            {
                creator.SetEmail(data["UserEmail"].ToString());
                creator.SetUserName(data["UserName"].ToString());
                creator.SetEventPosted(Convert.ToInt32(data["Eventposted"]));
                creator.SetFollowers(Convert.ToInt32(data["Followers"]));
                creator.SetUserID(Convert.ToInt32(data["UserID"]));
            }
        }
        data.Close();
        command.Dispose();
        DatabaseController.OpenConnexion(query).Connection.Close();
        return creator;
    }

    static public List<string> UserCreatorName()
    {
        List<string> UsercreatorName = new List<string>();
        String query = "SELECT u.UserName FROM Event e INNER JOIN Users u ON u.UserID = e.UserID WHERE DateEvent >= GETDATE()";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        SqlDataReader data = command.ExecuteReader();
        if (data.HasRows)
        {
            while (data.Read())
            {
                UsercreatorName.Add(data["Username"].ToString());
            }
        }

        data.Close();
        command.Dispose();
        DatabaseController.OpenConnexion(query).Connection.Close();
        return UsercreatorName;
    }
    public static List<Event> GetRecommendation(string UserID)
    {
        List<Event> recommendation = new List<Event>();
        string query = " select top(3) * from Event WHERE UserID = @UserID ORDER BY NEWID()";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@UserID", UserID);
        SqlDataReader data = command.ExecuteReader();
        if (data.HasRows)
        {
            while (data.Read())
            {
                Event e = new Event();
                e.EventId = Convert.ToInt32(data["EventID"]);
                e.Title = data["Title"].ToString();
                e.Description = data["Description"].ToString();
                e.Location = data["Location"].ToString();
                e.DateEvent = Convert.ToDateTime(data["DateEvent"]);
                var categoryString = data["Category"].ToString();
                if (Enum.TryParse(categoryString, out TypeofCategory category))
                {
                    e.Category = category;

                }
                recommendation.Add(e);
            }
        }
        return recommendation;
    }

}
