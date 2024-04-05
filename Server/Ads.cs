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
                    Id = reader.IsDBNull(reader.GetOrdinal("id")) ? (int?)null : reader.GetInt32("id"),
                    Headline = reader.IsDBNull(reader.GetOrdinal("headline")) ? null : reader.GetString("headline"),
                    County = reader.IsDBNull(reader.GetOrdinal("county")) ? null : reader.GetString("county"),
                    Dwelling = reader.IsDBNull(reader.GetOrdinal("dwelling")) ? null : reader.GetString("dwelling"),
                    DwellingOther = reader.IsDBNull(reader.GetOrdinal("dwellingOther")) ? null : reader.GetString("dwellingOther"),
                    Occupation = reader.IsDBNull(reader.GetOrdinal("occupation")) ? null : reader.GetString("occupation"),
                    RelStatus = reader.IsDBNull(reader.GetOrdinal("relStatus")) ? null : reader.GetString("relStatus"),
                    PartnerInfo = reader.IsDBNull(reader.GetOrdinal("partnerInfo")) ? null : reader.GetString("partnerInfo"),
                    ChildrenNum = reader.IsDBNull(reader.GetOrdinal("childrenNum")) ? (int?)null : reader.GetInt32("childrenNum"),
                    ChildrenHome = reader.IsDBNull(reader.GetOrdinal("childrenHome")) ? null : reader.GetString("childrenHome"),
                    Pets = reader.IsDBNull(reader.GetOrdinal("pets")) ? null : reader.GetString("pets"),
                    Dog = reader.IsDBNull(reader.GetOrdinal("dog")) ? null : reader.GetString("dog"),
                    Cat = reader.IsDBNull(reader.GetOrdinal("cat")) ? null : reader.GetString("cat"),
                    Bird = reader.IsDBNull(reader.GetOrdinal("bird")) ? null : reader.GetString("bird"),
                    Horse = reader.IsDBNull(reader.GetOrdinal("horse")) ? null : reader.GetString("horse"),
                    Other = reader.IsDBNull(reader.GetOrdinal("other")) ? null : reader.GetString("other"),
                    City = reader.IsDBNull(reader.GetOrdinal("city")) ? null : reader.GetString("city"),
                    CityAlternative = reader.IsDBNull(reader.GetOrdinal("cityAlternative")) ? null : reader.GetString("cityAlternative"),
                    Forest = reader.IsDBNull(reader.GetOrdinal("forest")) ? null : reader.GetString("forest"),
                    Sea = reader.IsDBNull(reader.GetOrdinal("sea")) ? null : reader.GetString("sea"),
                    Culture = reader.IsDBNull(reader.GetOrdinal("culture")) ? null : reader.GetString("culture"),
                    Shopping = reader.IsDBNull(reader.GetOrdinal("shopping")) ? null : reader.GetString("shopping"),
                    Car = reader.IsDBNull(reader.GetOrdinal("car")) ? (bool?)null : reader.GetBoolean("car"),
                    CarInfo = reader.IsDBNull(reader.GetOrdinal("carInfo")) ? null : reader.GetString("carInfo"),
                    Hobbies = reader.IsDBNull(reader.GetOrdinal("hobbies")) ? null : reader.GetString("hobbies"),
                    Presentation = reader.IsDBNull(reader.GetOrdinal("presentation")) ? null : reader.GetString("presentation"),
                    Age = reader.IsDBNull(reader.GetOrdinal("age")) ? (int?)null : reader.GetInt32("age"),
                    Gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? null : reader.GetString("gender"),
                    AdActive = reader.IsDBNull(reader.GetOrdinal("adActive")) ? (bool?)null : reader.GetBoolean("adActive"),
                    EndDate = reader.IsDBNull(reader.GetOrdinal("endDate")) ? (DateTime?)null : reader.GetDateTime("endDate"),
                    UserId = reader.IsDBNull(reader.GetOrdinal("userId")) ? (int?)null : reader.GetInt32("userId"),
                    EndTimestamp = reader.IsDBNull(reader.GetOrdinal("endTimestamp")) ? (int?)null : reader.GetInt32("endTimestamp"),
                    Children = reader.IsDBNull(reader.GetOrdinal("children")) ? null : reader.GetString("children")
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


