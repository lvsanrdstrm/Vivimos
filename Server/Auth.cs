﻿
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
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
                string result = string.Empty;
                string query = "SELECT id, role FROM users WHERE email = @Email AND password = @Password";
                MySqlCommand command = new(query, state.DB);

                command.Parameters.AddWithValue("@Email", loginRequest.Email);
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

            // Add logic to save the user to the database
            // For example:
            // userService.Register(user);

            // Return a success response
            ctx.Response.StatusCode = 200;
            await ctx.Response.WriteAsync("User registered successfully");
        }
        

        public record LoginRequest
        {
            public string Email { get; init; }
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



