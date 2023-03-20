using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using Event.Controllers;


namespace Event.Models;

class Users
{
    private int UserID;
    private string Email;
    private string Password;

    public static void Create(String UserEmail, String Password)
    {

        String query = "INSERT INTO Users (UserEmail, UserPassword) VALUES(@UserEmail, @UserPassword)";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@UserEmail", UserEmail);
        command.Parameters.AddWithValue("@UserPassword", Password);
        SqlDataReader data = command.ExecuteReader();
    }

}

