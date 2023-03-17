using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace Event;
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

        string connectionString = @"SERVER=LAPTOP-CM6ELO5N\MSSQLSERVER01;UID=LAPTOP-CM6ELO5N\\Côme;PWD=;DATABASE=EventDB;TrustServerCertificate=true;Integrated Security=true";
        // check \\
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        String select = "SELECT * FROM EVENT";
        String query = "INSERT INTO Event (Title, Description, Category, Location, DateEvent) VALUES(@Title, @Description, @Category, @Location, @DateEvent)";
        SqlCommand command = new SqlCommand(query, connection);
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
        connection.Close();
    }

    //     CREATE TABLE Users(
    // UserID int PRIMARY KEY IDENTITY(1,1),
    // UserEmail varchar(255) NOT NULL,
    // UserPassword varchar(255) NOT NULL,
    // CHECK (UserPassword LIKE '%[0-9]%'
    //                AND UserPassword LIKE '%[a-z]%'
    //                AND UserPassword LIKE '%[A-Z]%'
    //                AND UserPassword LIKE '%[^a-zA-Z0-9]%'),
    // EventID int NOT NULL,
    // FOREIGN KEY(EventID) REFERENCES Event(EventID)
}
