using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using static Server.Auth;

namespace Server
{
    public class Auctions
    {

        public static  IResult PlaceBid(int id, State state, ClaimsPrincipal User)
        {
    

            try
            {

                string query = "INSERT INTO bids (ad, bid) VALUES (@Ad, (SELECT ad FROM users where id = @UserId))";
                
                string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                MySqlHelper.ExecuteNonQuery(state.DB, query, [new("@Ad", id),new("@UserId",int.Parse(user))]);


                return TypedResults.Ok("Bid registered successfully");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                return TypedResults.Problem("Failed to register bid");
            }
        }

        public record Auction
        {
            public int? Id { get; set; }
            public int? Ad { get; set; }
            public int? Bid { get; set; }
        }
    }
}
