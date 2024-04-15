using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Server;

using MySql.Data.MySqlClient;


MySqlConnection? db = null;

string connectionString = "server=localhost;uid=root;pwd=mypassword;database=vivimos;port=3306";
var builder = WebApplication.CreateBuilder(args);


try
{
    db = new MySqlConnection(connectionString);
    db.Open();
    builder.Services.AddSingleton(new State(db));
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("admin_route", policy => policy.RequireRole("admin"));
    });
    builder.Services.AddAuthentication().AddCookie("opa23.molez.vivimos");
    var app = builder.Build();

    app.MapPost("/ads", Ads.AddAd);
    app.MapPost("/api/auth/register", Auth.Register);
    app.MapPost("/auth/login", Auth.Login);
    app.MapGet("/ad/{id}", Ads.GetSingle); //ska hämta den man vill ha
    app.MapGet("/ads", Ads.AllAds); // denna ska hämta alla
    app.MapPost("/ad/${id}/bid", Auctions.PlaceBid);
    app.Run("http://localhost:3001");

}
catch (MySqlException e)
{
    Console.WriteLine(e);
}
finally
{
    db?.Close();
}