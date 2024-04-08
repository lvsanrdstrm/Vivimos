using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;

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
                    Dwelling = reader.GetString("dwelling"),
                    DwellingOther = reader.GetString("dwellingOther"),
                    Occupation = reader.GetString("occupation"),
                    RelStatus = reader.GetString("relStatus"),
                    PartnerInfo = reader.GetString("partnerInfo"),
                    ChildrenNum = reader.GetInt32("childrenNum"),
                    ChildrenHome = reader.GetString("childrenHome"),
                    Pets = reader.GetString("pets"),
                    Dog = reader.GetString("dog"),
                    Cat = reader.GetString("cat"),
                    Bird = reader.GetString("bird"),
                    Horse = reader.GetString("horse"),
                    Other = reader.GetString("other"),
                    City = reader.GetString("city"),
                    CityAlternative = reader.GetString("cityAlternative"),
                    Forest = reader.GetString("forest"),
                    Sea = reader.GetString("sea"),
                    Culture = reader.GetString("culture"),
                    Shopping = reader.GetString("shopping"),
                    Car = reader.GetBoolean("car"),
                    CarInfo = reader.GetString("carInfo"),
                    Hobbies = reader.GetString("hobbies"),
                    Presentation = reader.GetString("presentation"),
                    Age = reader.GetInt32("age"),
                    Gender = reader.GetString("gender"),
                    AdActive = reader.GetBoolean("adActive"),
                    EndDate = reader.GetDateTime("endDate"),
                    UserId = reader.GetInt32("userId"),
                    EndTimestamp = reader.GetInt32("endTimestamp"),
                    Children = reader.GetString("children")

                };

                ads.Add(ad);

            }
        }


        return JsonConvert.SerializeObject(ads);
        /*await ctx.Response.WriteAsync(responseJson); // Await the WriteAsync method call
        return Results.Ok(); // Return an appropriate result*/

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


            command.Parameters.AddWithValue("@Headline", adData?.Headline);
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

