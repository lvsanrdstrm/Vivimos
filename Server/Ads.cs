using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Server;

    internal class Ads
    {
        public static string AllAds(State state, HttpContext ctx)
        {
            List<Ad> ads = new List<Ad>();
            string query = "SELECT * FROM ads";
            MySqlCommand command = new MySqlCommand(query, state.DB);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ad ad = new Ad
                    {
                        Name = reader.GetString("name"),
                        // osv allt som ska läsas
                        
                    };
                    ads.Add(ad);
                }
            }

            // Serialize the ads list to JSON
            return JsonConvert.SerializeObject(ads);
        }
    

    public static async Task<IResult> AddAd(State state, HttpContext ctx)
    {

        // Extract the ad data from the request body
        var requestBody = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
        var adData = JsonConvert.DeserializeObject<Ad>(requestBody);

        // Perform validation if needed

        // Insert the ad data into the database
        try
        {
            // tror man ska använda sig av någonslags sånhär command.parameters.add
            command.Parameters.Add(new SqlParameter("@Price", adData.Price));

            // och istället för command.executeread något i denna stil
            await command.ExecuteNonQueryAsync();

            // Return a success response
            ctx.Response.StatusCode = 200;
            await ctx.Response.WriteAsync("Ad added successfully");
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during database interaction
            ctx.Response.StatusCode = 500;
            await ctx.Response.WriteAsync($"Error adding ad: {ex.Message}");
        }
   
    }

    public class Ad
    {
        public string Name { get; init; }
        //osv osv hela formuläret
    }



}


