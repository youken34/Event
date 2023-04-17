using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using Event.Controllers;
using Newtonsoft.Json;

namespace Event.Models;

public class Users
{
    [JsonProperty("UserID")]
    private int UserID { get; set; }

    [JsonProperty("Email")]
    private string Email { get; set; }

    [JsonProperty("Password")]
    private string Password { get; set; }
    // JsonProperty permet a une instance de la classe User d'être transformer au format Json tout en gardant les attributs private
    public Users()
    {

    }

    public Users(int UserID, string Email, string Password)
    {
        this.UserID = UserID;
        this.Email = Email;
        this.Password = Password;
    }
    // Getter
    public int GetUserID()
    {
        return UserID;
    }
    public string GetEmail()
    {
        return Email;
    }
    public string GetPassword()
    {
        return Password;
    }

    // Setter
    public void SetUserID(int User)
    {
        UserID = User;
    }
    public void SetEmail(string mail)
    {
        Email = mail;
    }
    public void SetPassword(string pass)
    {
        Password = pass;
    }
    public static void Create(String UserEmail, String Password)
    {

        String query = "INSERT INTO Users (UserEmail, UserPassword) VALUES(@UserEmail, @UserPassword)";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@UserEmail", UserEmail);
        command.Parameters.AddWithValue("@UserPassword", Password);
        SqlDataReader data = command.ExecuteReader();
    }

}

