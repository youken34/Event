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
    public static int FindUserID(string Email, string Password)
    {
        int UserID = 0;
        SqlConnection connection = new SqlConnection(getconnexionString());
        connection.Open();
        String query = "SELECT UserID FROM Users WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@UserEmail", Email);
        byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(Password);
        byte[] enteredHashedBytes = SHA256.Create().ComputeHash(enteredPasswordBytes);
        string enteredHashedPassword = Convert.ToBase64String(enteredHashedBytes);
        command.Parameters.AddWithValue("@UserPassword", enteredHashedPassword);
        SqlDataReader read = command.ExecuteReader();
        while (read.HasRows)
        {
            read.Read();
            UserID = read.GetInt32(0);
        }
        Console.WriteLine(UserID);
        return UserID;
    }
}