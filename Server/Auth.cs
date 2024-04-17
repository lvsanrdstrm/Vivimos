
using System.Security.Authentication;
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
                string query = "SELECT id, role, email, username, ad FROM users WHERE username = @Username AND password = @Password";
                MySqlCommand command = new(query, state.DB);

                command.Parameters.AddWithValue("@Username", loginRequest.Username);
                command.Parameters.AddWithValue("@Password", loginRequest.Password);

                using (MySqlDataReader reader = command.ExecuteReader())
                {


                    if (reader.Read())
                    {

                        var user = new User
                        {
                            Id = reader.GetInt32("id"),
                            Username = reader.GetString("username"),
                            Email = reader.GetString("email"),
                            Role = reader.GetString("role"),
                            Ad = reader.GetInt32("ad")
                            // Add other properties as needed
                        };

                        Console.WriteLine($"User logged in: {user.Username} (ID: {user.Id}) (role: {user.Role})");


                        int id = reader.GetInt32("id");
                        string role = reader.GetString("role");


                        var claims = new List<Claim>
                    {
                        new(ClaimTypes.NameIdentifier, id.ToString()),
                        new(ClaimTypes.Role, role),
                    };

                        var claimsIdentity = new ClaimsIdentity(claims, "opa23.molez.vivimos");
                        await ctx.SignInAsync("opa23.molez.vivimos", new ClaimsPrincipal(claimsIdentity));



                        var userData = JsonConvert.SerializeObject(user);
                        ctx.Response.Headers.Add("Content-Type", "application/json");
                        return TypedResults.Ok(userData);
                    }
                }
                return TypedResults.Problem("Wrong email or password");
            }
            catch (InvalidCredentialException ex)
            {
                Console.WriteLine($"Invalid credentials: {ex.Message}");
                return TypedResults.Problem("Wrong email or password");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Unauthorized access: {ex.Message}");
                return TypedResults.Problem("Unauthorized access");
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
                // Create a SQL query to insert the user into the database
                string query = "INSERT INTO users (username, email, password, role) VALUES (@Username, @Email, @Password, 'user')";

                // Create a MySqlCommand object with the SQL query and database connection
                MySqlCommand command = new MySqlCommand(query, state.DB);

                // Add parameters to the command to prevent SQL injection
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);

                // Execute the SQL command to insert the user into the database
                await command.ExecuteNonQueryAsync();
                return TypedResults.Ok("User registered successfully");
            }
                      
            catch (MySqlException ex) when (ex.Number == 1062) // Error code for duplicate entry
            {
                Console.WriteLine($"Email already registered: {ex.Message}");
                return TypedResults.Problem("Email address is already registered.");
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




        public record User
        {
            public string? Username { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public int? Id { get; set; }
            public string? Role { get; set; }
            public int? Ad { get; set; }
            // Add any other properties as needed
        }
    }
}


