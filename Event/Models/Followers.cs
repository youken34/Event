using System.Data.SqlClient;
using Event.Controllers;
namespace Event.Models;
public class Followers
{
    public int followerID;
    public int followingID;

    public static bool isFollowing(int followerID, int followingID)
    {
        bool isFollowing = false;
        string query = "SELECT * from FOLLOWERS WHERE followerID = @followerID AND followingID = @followingID";
        SqlCommand command = DatabaseController.OpenConnexion(query);
        command.Parameters.AddWithValue("@followerID", followerID);
        command.Parameters.AddWithValue("@followingID", followingID);
        SqlDataReader data = command.ExecuteReader();
        if (data.HasRows)
        {
            isFollowing = true;
        }

        return isFollowing;
    }
}