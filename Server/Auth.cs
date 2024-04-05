
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


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

            // Example authentication logic:
            if (loginRequest.Username == "rosa.parks" && loginRequest.Password == "bus")
            {
                // Authentication successful
                Console.WriteLine(loginRequest.Username + loginRequest.Password);
                return Results.Ok("Authentication successful");
            }
            else
            {
                // Authentication failed
                return Results.BadRequest("Authentication failed");
            }


        }

        public static async Task<IResult> Register(State state, HttpContext ctx)
        {
            // Read the request body and deserialize it into a User object
            var requestBody = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
            var user = JsonConvert.DeserializeObject<User>(requestBody);

            // Add logic to save the user to the database
            // For example:
            // userService.Register(user);

            // Return a success response
            ctx.Response.StatusCode = 200;
            await ctx.Response.WriteAsync("User registered successfully");
        }
        

        public record LoginRequest
        {
            public string Username { get; init; }
            public string Password { get; init; }
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



