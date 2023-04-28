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
    private int? UserID { get; set; }

    [JsonProperty("Email")]
    private string Email { get; set; }

    [JsonProperty("Password")]
    private string? Password { get; set; }
    // JsonProperty permet a une instance de la classe User d'être transformer au format Json tout en gardant les attributs private
    [JsonProperty("Username")]
    private string Username { get; set; }
    [JsonProperty("FirstName")]
    private string? FirstName { get; set; }
    [JsonProperty("LastName")]
    private string? LastName { get; set; }
    [JsonProperty("Eventposted")]
    private int? Eventposted { get; set; }
    [JsonProperty("Followers")]
    private int? Followers { get; set; }
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
        return (int)UserID;
    }
    public string GetFirstName()
    {
        return FirstName;
    }
    public string GetLastName()
    {
        return LastName;
    }
    public string GetUserName()
    {
        return Username;
    }
    public string GetEmail()
    {
        return Email;
    }
    public string GetPassword()
    {
        return Password;
    }
    public int GetEventposted()
    {
        return (int)Eventposted;
    }
    public int GetFollowers()
    {
        return (int)Followers;
    }


    // Setter
    public void SetUserID(int User)
    {
        UserID = User;
    }
    public void SetFirstName(string firstname)
    {
        FirstName = firstname;
    }
    public void SetLastName(string lastname)
    {
        LastName = lastname;
    }
    public void SetUserName(string username)
    {
        Username = username;
    }
    public void SetEmail(string mail)
    {
        Email = mail;
    }
    public void SetPassword(string pass)
    {
        Password = pass;
    }
    public void SetEventPosted(int eventposted)
    {
        Eventposted = eventposted;
    }
    public void SetFollowers(int followers)
    {
        Followers = followers;
    }


    public static void Create(String FirstName, String LastName, String Username, String UserEmail, String Password)
    {

        String query = "INSERT INTO Users (UserEmail, UserPassword, UserFirstName, UserLastName, UserName) VALUES(@UserEmail, @UserPassword, @UserFirstName, @UserLastName, @UserName)";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@UserEmail", UserEmail);
        command.Parameters.AddWithValue("@UserPassword", Password);
        command.Parameters.AddWithValue("@UserFirstName", FirstName);
        command.Parameters.AddWithValue("@UserLastName", LastName);
        command.Parameters.AddWithValue("@UserName", Username);

        command.ExecuteReader();
    }

}

