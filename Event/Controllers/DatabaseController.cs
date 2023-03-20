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
}