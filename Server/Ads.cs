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
                    Id = reader.GetInt32("id"),
                    Headline = reader.GetString("headline"),
                    County = reader.GetString("county"),
                    Occupation = reader.GetString("occupation"),
                    Age = reader.GetInt32("age"),
                    Car = reader.GetBoolean("car"),
                    Gender = reader.GetString("gender"),
                    AdActive = reader.GetBoolean("adActive")

                };
                ads.Add(ad);
            }
        }

        // Serialize the ads list to JSON
        return JsonConvert.SerializeObject(ads);
    }

    /* public static async Task<IResult> AddAd(State state, HttpContext ctx)
     {

         // Extract the ad data from the request body
         var requestBody = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
         var adData = JsonConvert.DeserializeObject<Ad>(requestBody);
         MySqlCommand command = new(query, state.DB);
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

     }*/

    public record Ad
    {
        public int? Id { get; init; }
        public string? Headline { get; init; }
        public string? County { get; init; }
        public string? Dwelling { get; init; }
        public string? DwellingOther { get; init; }
        public string? Occupation { get; init; }
        public string? RelStatus { get; init; }
        public string? PartnerInfo { get; init; }
        public int? ChildrenNum { get; init; }
        public string? ChildrenHome { get; init; }
        public string? Pets { get; init; }
        public string? Dog { get; init; }
        public string? Cat { get; init; }
        public string? Bird { get; init; }
        public string? Horse { get; init; }
        public string? Other { get; init; }
        public string? City { get; init; }
        public string? CityAlternative { get; init; }
        public string? Forest { get; init; }
        public string? Sea { get; init; }
        public string? Culture { get; init; }
        public string? Shopping { get; init; }
        public bool? Car { get; init; }
        public string? CarInfo { get; init; }
        public string? Hobbies { get; init; }
        public string? Presentation { get; init; }
        public int? Age { get; init; }
        public string? Gender { get; init; }
        public bool? AdActive { get; init; }
        public DateTime? EndDate { get; init; }
        public int? UserId { get; init; }
        public int? EndTimestamp { get; init; }
        public string? Children { get; init; }
    }




}


