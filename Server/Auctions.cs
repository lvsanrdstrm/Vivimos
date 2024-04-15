using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using static Server.Auth;

namespace Server
{
    public class Auctions
    {

        public static async Task<IResult> PlaceBid(State state, HttpContext ctx)
        {
            var requestBody = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
            var auction = JsonConvert.DeserializeObject<Auction>(requestBody);
            Console.WriteLine("hej");
            var id = ctx.Request.RouteValues["id"];

            try
            {
                await using var transaction = await state.DB.BeginTransactionAsync();

                string query = "INSERT INTO bids (ad, bid) VALUES (@Ad, @Bid)";
                MySqlCommand command = new MySqlCommand(query, state.DB);
                command.Parameters.AddWithValue("@Ad", auction.Ad);
                command.Parameters.AddWithValue("@Bid", auction.Bid);

                await command.ExecuteNonQueryAsync();

                await transaction.CommitAsync();

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
