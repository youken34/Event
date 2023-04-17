using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event.Models;
using System.Text.RegularExpressions;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using Event.Models;



namespace Event.Controllers;

public class DatabaseController : Controller
{
    public static String getconnexionString()
    {
        string connectionString = @"SERVER=LAPTOP-CM6ELO5N\MSSQLSERVER01;UID=LAPTOP-CM6ELO5N\\Côme;PWD=;DATABASE=EventDB;TrustServerCertificate=true;Integrated Security=true";
        return connectionString;
    }
    public static SqlCommand OpenConnexion(string query)
    {
        SqlConnection connection = new SqlConnection(getconnexionString());
        connection.Open();
        SqlCommand command = new SqlCommand(query, connection);
        return command;
    }

    public static void InsertInto()
    {

    }
    public static Users FindUser(string Email, string Password)
    {
        Users userFound = new Users();
        SqlConnection connection = new SqlConnection(getconnexionString());
        connection.Open();
        String query = "SELECT * FROM Users WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword";
        byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(Password);
        byte[] enteredHashedBytes = SHA256.Create().ComputeHash(enteredPasswordBytes);
        string enteredHashedPassword = Convert.ToBase64String(enteredHashedBytes);
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@UserEmail", Email);
        command.Parameters.AddWithValue("@UserPassword", enteredHashedPassword);
        SqlDataReader data = command.ExecuteReader();
        if (data.HasRows)
        {
            while (data.Read())
            {
                userFound.SetUserID(Convert.ToInt32(data["UserID"]));
                userFound.SetEmail(data["UserEmail"].ToString());
                userFound.SetPassword(data["UserPassword"].ToString());
            }
        }
        data.Close();
        command.Dispose();
        DatabaseController.OpenConnexion(query).Connection.Close();
        return userFound;
    }
}