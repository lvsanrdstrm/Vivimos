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

        string query = "INSERT INTO ads (headline, county, occupation) VALUES (@Headline, @County, @Occupation)";
        MySqlCommand command = new MySqlCommand(query, state.DB);

       
        command.Parameters.AddWithValue("@Description", adData.Headline);
        command.Parameters.AddWithValue("@County", adData.County);
        command.Parameters.AddWithValue("@Occupation", adData.Occupation);

        try
        {
            // Execute the SQL command to insert the ad into the database
            await command.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during database interaction
            ctx.Response.StatusCode = 500;
            await ctx.Response.WriteAsync($"Error adding ad: {ex.Message}");
        }
   
    }

      public record Ad
    {
        public int Id { get; init; }
        public string Headline { get; init; }
        public string County { get; init; }
        public string Occupation { get; init; }
        public int Age { get; init; }
        public bool Car { get; init; }
        public string Gender { get; init; }
 
    }



}


