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



namespace Event.Models;
public class Event
{
    private int EventId { get; set; }
    private string Title { get; set; }
    private string Description { get; set; }
    private string Category { get; set; }
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
        return Category;
    }
    public string GetLocation()
    {
        return Location;
    }

    public DateTime GetDate()
    {
        return DateEvent;
    }
    public static void InsertEvent(string Title, string Description, string Category, string Location, DateTime DateEvent, int UserID)
    {
        String query = "INSERT INTO Event (Title, Description, Category, Location, DateEvent, UserID) VALUES(@Title, @Description, @Category, @Location, @DateEvent, @UserID)";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@Title", Title);
        command.Parameters.AddWithValue("@Description", Description);
        command.Parameters.AddWithValue("@Category", Category);
        command.Parameters.AddWithValue("@Location", Location);
        command.Parameters.AddWithValue("@DateEvent", DateEvent.ToString("MM/dd/yyyy hh:mm:ss tt"));
        command.Parameters.AddWithValue("@UserID", UserID);
        SqlDataReader data = command.ExecuteReader();

        while (data.Read())
        {
            Console.WriteLine($"Values added : Title : {data["Title"]}, Description : {data["Description"]}, Category : {data["Category"]}, Location : {data["Location"]}, Date : {data["DateEvent"]}");
        }
        data.Close();
        command.Dispose();
        DatabaseController.OpenConnexion(query).Connection.Close();
    }
    public static List<Event> MyEvents(string UserID)
    {
        List<Event> myevents = new List<Event>();
        String query = "SELECT * FROM EVENT WHERE UserID = @UserID";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@UserID", UserID);
        Console.WriteLine(UserID);
        SqlDataReader data = command.ExecuteReader();
        if (data.HasRows)
        {
            while (data.Read())
            {
                Event eventItem = new Event();
                eventItem.EventId = Convert.ToInt32(data["EventID"]);
                eventItem.Title = data["Title"].ToString();
                eventItem.Description = data["Description"].ToString();
                eventItem.Category = data["Category"].ToString();
                eventItem.Location = data["Location"].ToString();
                eventItem.DateEvent = Convert.ToDateTime(data["DateEvent"]);
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
                eventItem.Category = data["Category"].ToString();
                eventItem.Location = data["Location"].ToString();
                eventItem.DateEvent = Convert.ToDateTime(data["DateEvent"]);
                recentEvent.Add(eventItem);
            }
        }

        data.Close();
        command.Dispose();
        DatabaseController.OpenConnexion(query).Connection.Close();
        return recentEvent;
    }


}
