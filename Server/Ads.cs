using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;

namespace Server;

internal class Ads
{

    public static string GetSingle(State state, HttpContext ctx)
    {
        var id = ctx.Request.RouteValues["id"];

        // Check if id is not null and is of the correct type
        if (id != null && int.TryParse(id.ToString(), out int adId))
        {
            List<Ad> ads = new List<Ad>();
            string query = "SELECT * FROM ads WHERE id = @Id";

            using (MySqlCommand command = new MySqlCommand(query, state.DB))
            {
                command.Parameters.AddWithValue("@Id", adId);

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

                return JsonConvert.SerializeObject(ads);
            }
        }
        else
        {
            // Handle the case where id is not provided or is invalid
            // For example, return an error message
            return "Invalid or missing id parameter";
        }
    }


    public static string AllAds(State state, HttpContext ctx)
    {
        List<Ad> ads = new List<Ad>();
        string query = "SELECT * FROM ads";


        using (MySqlCommand command = new MySqlCommand(query, state.DB))
        {

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

        }
        return JsonConvert.SerializeObject(ads);
        /*  await ctx.Response.WriteAsync(responseJson); // Await the WriteAsync method call
         return Results.Ok(); // Return an appropriate result */
    }

    public static async Task<IResult> AddAd(State state, HttpContext ctx)
    {

        // Extract the ad data from the request body
        var requestBody = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
        var adData = JsonConvert.DeserializeObject<Ad>(requestBody);
        try
        {
            string query = @"
            INSERT INTO ads (
                headline, county, dwelling, dwellingOther, occupation, relStatus, partnerInfo, 
                childrenNum, childrenHome, pets, dog, cat, bird, horse, other, city, cityAlternative, 
                forest, sea, culture, shopping, car, carInfo, hobbies, presentation, age, gender, 
                adActive, endDate, userId, endTimestamp, children
            ) 
            VALUES (
                @Headline, @County, @Dwelling, @DwellingOther, @Occupation, @RelStatus, @PartnerInfo,
                @ChildrenNum, @ChildrenHome, @Pets, @Dog, @Cat, @Bird, @Horse, @Other, @City, @CityAlternative,
                @Forest, @Sea, @Culture, @Shopping, @Car, @CarInfo, @Hobbies, @Presentation, @Age, @Gender,
                @AdActive, @EndDate, @UserId, @EndTimestamp, @Children
            )";

            MySqlCommand command = new MySqlCommand(query, state.DB);


            command.Parameters.AddWithValue("@Headline", adData.Headline);
            command.Parameters.AddWithValue("@County", adData.County);
            command.Parameters.AddWithValue("@Dwelling", adData.Dwelling);
            command.Parameters.AddWithValue("@DwellingOther", adData.DwellingOther);
            command.Parameters.AddWithValue("@Occupation", adData.Occupation);
            command.Parameters.AddWithValue("@RelStatus", adData.RelStatus);
            command.Parameters.AddWithValue("@PartnerInfo", adData.PartnerInfo);
            command.Parameters.AddWithValue("@ChildrenNum", adData.ChildrenNum);
            command.Parameters.AddWithValue("@ChildrenHome", adData.ChildrenHome);
            command.Parameters.AddWithValue("@Pets", adData.Pets);
            command.Parameters.AddWithValue("@Dog", adData.Dog);
            command.Parameters.AddWithValue("@Cat", adData.Cat);
            command.Parameters.AddWithValue("@Bird", adData.Bird);
            command.Parameters.AddWithValue("@Horse", adData.Horse);
            command.Parameters.AddWithValue("@Other", adData.Other);
            command.Parameters.AddWithValue("@City", adData.City);
            command.Parameters.AddWithValue("@CityAlternative", adData.CityAlternative);
            command.Parameters.AddWithValue("@Forest", adData.Forest);
            command.Parameters.AddWithValue("@Sea", adData.Sea);
            command.Parameters.AddWithValue("@Culture", adData.Culture);
            command.Parameters.AddWithValue("@Shopping", adData.Shopping);
            command.Parameters.AddWithValue("@Car", adData.Car);
            command.Parameters.AddWithValue("@CarInfo", adData.CarInfo);
            command.Parameters.AddWithValue("@Hobbies", adData.Hobbies);
            command.Parameters.AddWithValue("@Presentation", adData.Presentation);
            command.Parameters.AddWithValue("@Age", adData.Age);
            command.Parameters.AddWithValue("@Gender", adData.Gender);
            command.Parameters.AddWithValue("@AdActive", adData.AdActive);
            command.Parameters.AddWithValue("@EndDate", adData.EndDate);
            command.Parameters.AddWithValue("@UserId", adData.UserId);
            command.Parameters.AddWithValue("@EndTimestamp", adData.EndTimestamp);
            command.Parameters.AddWithValue("@Children", adData.Children);


            // Execute the SQL command to insert the ad into the database
            await command.ExecuteNonQueryAsync();
            return TypedResults.Ok("Ad added successfully");
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during database interaction
            Console.WriteLine($"Error adding ad: {ex.Message}");
            return TypedResults.Problem("An error occurred while adding the ad.");
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
