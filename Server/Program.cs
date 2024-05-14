using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.FileProviders;

using Server;

using MySql.Data.MySqlClient;



string connectionString = "server=localhost;uid=root;pwd=mypassword;database=vivimos;port=3306";
var builder = WebApplication.CreateBuilder(args);

try
{

    builder.Services.AddSingleton(new State(connectionString));
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("admin_route", policy => policy.RequireRole("admin"));
        options.AddPolicy("user", policy => policy.RequireRole("user"));

    });
    builder.Services.AddAuthentication().AddCookie("opa23.molez.vivimos");
builder.WebHost.ConfigureKestrel(serverOptions =>
{
  serverOptions.ListenAnyIP(3000);
});

    var app = builder.Build();

    // Här deklarerar vi två variabler: en som håller i vår PATH till vår dist map/folder.
// Den andra är en class som håller i distmappen som vi vill att vår backend ska hantera.
    var distPath = Path.Combine(app.Environment.ContentRootPath, "dist");
var fileProvider = new PhysicalFileProvider(distPath);

app.UseHttpsRedirection();

// Här deklarerar vi att vår app ska använda sig av vår distmapp alltid som en fallback.
app.UseDefaultFiles(new DefaultFilesOptions
{
  FileProvider = fileProvider,
  DefaultFileNames = new List<string> { "index.html" }
});

// Här deklarerar vi att vår app ska hantera statiska filer (vår distmapp)
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider= fileProvider,
  RequestPath = ""
});

app.UseRouting();

// MapFallback gör så att när det skrivs in en URL i webläsaren som vår backend inte känner igen, så ska den // skicka tillbaka vår index.html som ligger i dist (dist/index.html) och låta frontend ta hand om routingen.
// Det är default use case när man jobbar med en SPA ( Single Page Application ) så som ramverket React etc.

app.MapFallback(async context =>
{

  context.Response.ContentType = "text/html";
  await context.Response.SendFileAsync(Path.Combine(distPath, "index.html"));

});
    app.MapPost("/api/ads", Ads.AddAd);
    app.MapPost("/api/auth/register", Auth.Register);
    app.MapPost("/api/auth/login", Auth.Login);
    app.MapGet("/api/ad/{id}", Ads.GetSingle); //ska hämta den man vill ha
    app.MapGet("/api/ads", Ads.AllAds); // denna ska hämta alla
    app.MapPost("/api/bids/{id}", Auctions.PlaceBid).RequireAuthorization("user");
    app.Run();

}
catch (MySqlException e)
{
    Console.WriteLine(e);
}
