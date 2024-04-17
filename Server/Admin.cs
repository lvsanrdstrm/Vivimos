using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Server.Ads;

namespace Server
{
    internal class Admin
    {
        public static string AllUsers(State state, HttpContext ctx)
        {
            List<User> users = new List<User>();
            string query = "SELECT id, username, email, role, ad FROM users";
            MySqlCommand command = new MySqlCommand(query, state.DB);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        Id = reader.GetInt32("id"),
                        Username = reader.GetString("username"),
                        Email = reader.GetString("email"),
                        Role = reader.GetString("role"),
                        Ad = reader.GetInt32("ad")

                    };

                    users.Add(user);

                }

            }
            return JsonConvert.SerializeObject(users);

        }



        public record User
        {
            public int? Id { get; set; }
            public string? Username { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? Role { get; set; }
            public int? Ad { get; set; }
            // Add any other properties as needed
        }
    }
}
