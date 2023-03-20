using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using Event.Controllers;

namespace Event.Models;
public class Event
{
    private int EventId = 1;
    private string Title { get; set; }
    private string Description { get; set; }
    private string Category { get; set; }
    private string Location { get; set; }
    private DateTime DateEvent { get; set; }


    public static void InsertEvent(string Title, string Description, string Category, string Location, DateTime DateEvent)
    {


        String query = "INSERT INTO Event (Title, Description, Category, Location, DateEvent) VALUES(@Title, @Description, @Category, @Location, @DateEvent)";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@Title", Title);
        command.Parameters.AddWithValue("@Description", Description);
        command.Parameters.AddWithValue("@Category", Category);
        command.Parameters.AddWithValue("@Location", Location);
        command.Parameters.AddWithValue("@DateEvent", DateEvent);
        SqlDataReader data = command.ExecuteReader();

        while (data.Read())
        {
            Console.WriteLine($"Values added : Title : {data["Title"]}, Description : {data["Description"]}, Category : {data["Category"]}, Location : {data["Location"]}, Date : {data["DateEvent"]}");
        }
        DatabaseController.OpenConnexion(query).Connection.Close();
    }


}
