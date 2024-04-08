
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using static Server.Ads;
using static Server.Auth;


namespace Server
{
    internal class Auth
    {
        public static async Task<IResult> Login(State state, HttpContext ctx)
        {
            var request = ctx.Request;
            var requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var loginRequest = JsonConvert.DeserializeObject<LoginRequest>(requestBody);

            // Implement authentication logic using loginRequest.Username and loginRequest.Password

            try
            {
                string query = "SELECT id, role FROM users WHERE username = @Username AND password = @Password";
                MySqlCommand command = new(query, state.DB);

                command.Parameters.AddWithValue("@Username", loginRequest.Username);
                command.Parameters.AddWithValue("@Password", loginRequest.Password);

                using MySqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string role = reader.GetString("role");

                    Console.WriteLine(id + ", " + role);
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.NameIdentifier, id.ToString()),
                        new(ClaimTypes.Role, role),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "opa23.molez.vivimos");
                    await ctx.SignInAsync("opa23.molez.vivimos", new ClaimsPrincipal(claimsIdentity));


                    return TypedResults.Ok("Signed in");
                }
                return TypedResults.Problem("Wrong email or password");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                return TypedResults.Problem("An error occurred during login.");
            }

        }

        public static async Task<IResult> Register(State state, HttpContext ctx)
        {
            // Read the request body and deserialize it into a User object
            var requestBody = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
            var user = JsonConvert.DeserializeObject<User>(requestBody);

            try
            {
                string query = @"
            INSERT INTO users (
                username, email, password
            ) 
            VALUES (
                @Username, @email, @password
            )";

                MySqlCommand command = new MySqlCommand(query, state.DB);


                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);


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

            // Add logic to save the user to the database
            // For example:
            // userService.Register(user);
        }


        public record LoginRequest
        {
            public string? Username { get; init; }
            public string? Password { get; init; }
        }




        public class User
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            // Add any other properties as needed
        }
    }
}


