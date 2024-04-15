using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Server;

/* internal class Users
    {
        public static async Task<IResult>Single(State state, HttpContext ctx)
    {

        var request = ctx.Request;
        var requestBody = await new StreamReader(request.Body).ReadToEndAsync();
        var userRequest = JsonConvert.DeserializeObject<UserRequest>(requestBody);
        MySqlCommand command = new("SELECT username FROM users WHERE userId = @input", state.DB);

        command.Parameters.AddWithValue("@input", userReqeust.username);

        var username = command.ExecuteScalar();

        if (username is string s)
        {
            return JsonConvert.SerializeObject(username);
        }
    }

    public record UserRequest
        {
            public string? Username { get; init; }

        }
 

    }*/
