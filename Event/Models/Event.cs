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
    private enum TypeofCategory
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
        SqlDataReader data = command.ExecuteReader();

        while (data.Read())
        {
            Console.WriteLine($"Values added : Title : {data["Title"]}, Description : {data["Description"]}, Category : {data["Category"]}, Location : {data["Location"]}, Date : {data["DateEvent"]}");
        }
        data.Close();
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


}
