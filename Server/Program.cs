using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/auth/login", async (HttpContext context) =>
{
    var request = context.Request;
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

});

//app.MapPost("/auth/login", () => @"
//[
//    {
//      ""id"": ""1"",
//      ""username"": ""rosa_parks"",
//      ""email"": ""rosa.parks@example.com"",
//      ""password"": ""bus"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""2"",
//      ""username"": ""malala_yousafzai"",
//      ""email"": ""malala.yousafzai@example.com"",
//      ""password"": ""nobelpeaceprize"",
//      ""role"": ""admin""
//    },
//    {
//      ""id"": ""3"",
//      ""username"": ""emma_watson"",
//      ""email"": ""emma.watson@example.com"",
//      ""password"": ""heforshe"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""4"",
//      ""username"": ""bell_hooks"",
//      ""email"": ""bell.hooks@example.com"",
//      ""password"": ""feministtheory"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""5"",
//      ""username"": ""sojourner_truth"",
//      ""email"": ""sojourner.truth@example.com"",
//      ""password"": ""aintiawoman"",
//      ""role"": ""admin""
//    },
//    {
//      ""id"": ""63b0"",
//      ""username"": ""aagrg"",
//      ""email"": ""erik.cronqvist@gmail.com"",
//      ""password"": ""aefaef""
//    },
//    {
//      ""id"": ""8dde"",
//      ""username"": ""aaga"",
//      ""email"": ""erik.cronqvist@gmail.com"",
//      ""password"": ""gagaga"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""e712"",
//      ""username"": ""bauta"",
//      ""email"": ""efeo@geo.com"",
//      ""password"": ""oioioioi"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""ad58"",
//      ""username"": ""micke"",
//      ""email"": ""mikaelfant@gmail.com"",
//      ""password"": ""123"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""8224"",
//      ""username"": ""fefefef"",
//      ""email"": ""erik.cronqvist@gmail.com"",
//      ""password"": ""efe"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""0150"",
//      ""username"": ""micke"",
//      ""email"": ""mikaelfant@gmail.com"",
//      ""password"": ""123"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""d4fe"",
//      ""username"": ""micke2"",
//      ""email"": ""mikaelfant@gmail.com"",
//      ""password"": ""1212"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""b456"",
//      ""username"": ""brillinat_emma"",
//      ""email"": ""emma@trinket.us"",
//      ""password"": ""wow"",
//      ""role"": ""user""
//    },
//    {
//      ""id"": ""4dfc"",
//      ""username"": ""idiot"",
//      ""email"": ""apa@gmail.com"",
//      ""password"": ""q"",
//      ""role"": ""user""
//    }
//  ]");
app.MapGet("/ads", () => @"
[
    {
      ""id"": ""f1d9"",
      ""rubrik"": ""Frihet & fantasi"",
      ""l�n"": ""Halland"",
      ""boende"": ""L�genhet"",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""Mellanchef"",
      ""relstatus"": ""ensamvarg"",
      ""partnerinfo"": """",
      ""barnAntal"": """",
      ""barnBoende"": """",
      ""husdjurHar"": true,
      ""husdjurHund"": false,
      ""husdjurKatt"": true,
      ""husdjurF�gel"": false,
      ""husdjurH�st"": false,
      ""husdjurAnnat"": ""Gris"",
      ""stad"": ""Mellanstor stad"",
      ""stadAlternativ"": """",
      ""boendeSkog"": false,
      ""boendeHav"": false,
      ""boendeKultur"": false,
      ""boendeShopping"": true,
      ""bil"": true,
      ""bilinfo"": ""Ford Taunus"",
      ""barn"": false,
      ""fritidsintressen"": """",
      ""presentation"": ""Tjolahopp"",
      ""�lder"": ""18"",
      ""k�n"": ""Man"",
      ""bids"": [
        ""8dde"",
        null,
        null,
        null,
        null,
        ""1"",
        ""e712"",
        ""1""
      ]
    },
    {
      ""id"": ""b4ed"",
      ""rubrik"": ""Enkelhet och lugn & ro p� landet!"",
      ""l�n"": ""Sk�ne"",
      ""boende"": ""Husvagn"",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""sjukpension�r"",
      ""relstatus"": ""ensamvarg"",
      ""partnerinfo"": """",
      ""barnAntal"": """",
      ""barnBoende"": """",
      ""husdjurHar"": true,
      ""husdjurHund"": false,
      ""husdjurKatt"": false,
      ""husdjurF�gel"": false,
      ""husdjurH�st"": false,
      ""husdjurAnnat"": ""tv� illrar"",
      ""stad"": ""Bystan"",
      ""stadAlternativ"": """",
      ""boendeSkog"": true,
      ""boendeHav"": true,
      ""boendeKultur"": false,
      ""boendeShopping"": false,
      ""bil"": false,
      ""bilinfo"": """",
      ""barn"": false,
      ""fritidsintressen"": ""fiskar, plockar b�r och svamp, virkar, trippar"",
      ""presentation"": ""Tjofl�jt"",
      ""�lder"": ""54"",
      ""k�n"": ""Kvinna"",
      ""bids"": [
        ""8dde""
      ]
    },
    {
      ""id"": ""a807"",
      ""rubrik"": ""Gay �ldre lyx&kulturman"",
      ""l�n"": ""Stockholm"",
      ""boende"": ""L�genhet"",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""pension�r"",
      ""relstatus"": ""singel"",
      ""partnerinfo"": """",
      ""barnAntal"": """",
      ""barnBoende"": """",
      ""husdjurHar"": false,
      ""husdjurHund"": false,
      ""husdjurKatt"": false,
      ""husdjurF�gel"": false,
      ""husdjurH�st"": false,
      ""husdjurAnnat"": """",
      ""stad"": ""Storstad"",
      ""stadAlternativ"": ""Centralt"",
      ""boendeSkog"": false,
      ""boendeHav"": false,
      ""boendeKultur"": true,
      ""boendeShopping"": true,
      ""bil"": false,
      ""bilinfo"": """",
      ""barn"": false,
      ""fritidsintressen"": ""raggar unga m�n, g�r p� opera, �ter dyrt, promenerar p� Djurg�rden"",
      ""presentation"": ""tjiipppi"",
      ""�lder"": ""77"",
      ""k�n"": ""Man"",
      ""bids"": [
        ""8dde""
      ]
    },
    {
      ""id"": ""ee84"",
      ""rubrik"": ""Zombielycka"",
      ""l�n"": ""Blekinge"",
      ""boende"": ""Villa"",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""Hemmafru"",
      ""relstatus"": ""exklusiv sambo"",
      ""partnerinfo"": ""44"",
      ""barnAntal"": """",
      ""barnBoende"": """",
      ""husdjurHar"": false,
      ""husdjurHund"": false,
      ""husdjurKatt"": false,
      ""husdjurF�gel"": false,
      ""husdjurH�st"": false,
      ""husdjurAnnat"": """",
      ""stad"": ""Sm�stad"",
      ""stadAlternativ"": """",
      ""boendeSkog"": true,
      ""boendeHav"": false,
      ""boendeKultur"": false,
      ""boendeShopping"": true,
      ""bil"": false,
      ""bilinfo"": """",
      ""barn"": false,
      ""fritidsintressen"": ""Sover, �ter benso"",
      ""presentation"": ""flipflip"",
      ""�lder"": ""33"",
      ""k�n"": ""Kvinna"",
      ""bids"": [
        ""8dde""
      ]
    },
    {
      ""id"": ""c07d"",
      ""rubrik"": ""This is it"",
      ""l�n"": ""V�sterbotten"",
      ""boende"": ""Husvagn"",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""brandman"",
      ""relstatus"": ""�ppen s�rbo"",
      ""partnerinfo"": ""britta 48"",
      ""barnAntal"": """",
      ""barnBoende"": """",
      ""husdjur"": """",
      ""Hund"": """",
      ""Katt"": """",
      ""F�gel"": """",
      ""H�st"": """",
      ""Annat"": """",
      ""stad"": ""Sm�stad"",
      ""stadAlternativ"": """",
      ""Skog"": """",
      ""Hav"": ""Hav / Sj�"",
      ""Kultur"": """",
      ""Shopping"": """",
      ""bil"": """",
      ""bilinfo"": """",
      ""barn"": """",
      ""fritidsintressen"": ""spelar poker"",
      ""presentation"": ""Do you want to eat ice cream?"",
      ""�lder"": ""37"",
      ""k�n"": ""Kvinna"",
      ""publicerad"": true,
      ""enddate"": ""2024-04-30"",
      ""userId"": ""8224"",
      ""endTimestamp"": 1714435200000,
      ""bids"": [
        ""b456""
      ]
    },
    {
      ""id"": ""62e0"",
      ""rubrik"": ""Frihet & fantasi"",
      ""l�n"": ""Sk�ne"",
      ""boende"": ""L�genhet"",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""studerande"",
      ""relstatus"": ""exklusiv s�rbo"",
      ""partnerinfo"": """",
      ""barnAntal"": ""1"",
      ""barnBoende"": ""Delvis"",
      ""husdjur"": """",
      ""Hund"": """",
      ""Katt"": """",
      ""F�gel"": """",
      ""H�st"": """",
      ""Annat"": """",
      ""stad"": ""Storstad"",
      ""stadAlternativ"": """",
      ""Skog"": """",
      ""Hav"": ""Hav / Sj�"",
      ""Kultur"": ""Kultur"",
      ""Shopping"": ""Shopping"",
      ""bil"": ""bil"",
      ""bilinfo"": ""Mercedes"",
      ""barn"": ""barn"",
      ""fritidsintressen"": ""Spelar musik, lyssnar p� musik, mm"",
      ""presentation"": ""Programmeringsstuderande 52-�rig separerad  kulturman (utgiven romanf�rfattare, �vers�ttare) med s�rbeg�vad varannanhelgsdotter och frispr�kig, sexglad (kvinnlig) ingenj�rss�rbo, samt s�llanrepande improvisationskrautband. Familjefritt boende i centrala Malm�. \n"",
      ""�lder"": ""52"",
      ""k�n"": ""Man"",
      ""publicerad"": true,
      ""enddate"": ""2024-03-30"",
      ""userId"": ""d4fe"",
      ""endTimestamp"": 1711756800000,
      ""bids"": [
        ""b456""
      ]
    },
    {
      ""id"": ""6d36"",
      ""rubrik"": ""efw"",
      ""l�n"": """",
      ""boende"": """",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""sd"",
      ""relstatus"": """",
      ""partnerinfo"": """",
      ""barnAntal"": """",
      ""barnBoende"": """",
      ""husdjur"": """",
      ""Hund"": """",
      ""Katt"": """",
      ""F�gel"": """",
      ""H�st"": """",
      ""Annat"": """",
      ""stad"": """",
      ""stadAlternativ"": """",
      ""Skog"": """",
      ""Hav"": """",
      ""Kultur"": """",
      ""Shopping"": """",
      ""bil"": """",
      ""bilinfo"": """",
      ""barn"": """",
      ""fritidsintressen"": ""wed"",
      ""presentation"": ""wd"",
      ""�lder"": """",
      ""k�n"": """",
      ""publicerad"": false,
      ""enddate"": """",
      ""userId"": ""b456"",
      ""endTimestamp"": null
    },
    {
      ""id"": ""50e6"",
      ""rubrik"": ""vardagsromantism vid en sj�"",
      ""l�n"": ""Blekinge"",
      ""boende"": ""Husvagn"",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""v�vare"",
      ""relstatus"": ""knasigt"",
      ""partnerinfo"": """",
      ""barnAntal"": """",
      ""barnBoende"": """",
      ""husdjur"": ""husdjur"",
      ""Hund"": """",
      ""Katt"": """",
      ""F�gel"": ""F�gel"",
      ""H�st"": """",
      ""Annat"": ""m�ss"",
      ""stad"": ""Bystan"",
      ""stadAlternativ"": """",
      ""Skog"": """",
      ""Hav"": ""Hav / Sj�"",
      ""Kultur"": ""Kultur"",
      ""Shopping"": """",
      ""bil"": """",
      ""bilinfo"": """",
      ""barn"": """",
      ""fritidsintressen"": ""dr�mmer och skriver dikter"",
      ""presentation"": ""jag �r en modern version av lord byron. take it or leave it."",
      ""�lder"": ""22"",
      ""k�n"": ""Man"",
      ""publicerad"": true,
      ""enddate"": ""2024-03-30"",
      ""userId"": ""b456"",
      ""endTimestamp"": 1711756800000,
      ""bids"": [
        ""b456""
      ]
    },
    {
      ""id"": ""b816"",
      ""rubrik"": ""djupa suckar och h�ga st�mningar"",
      ""l�n"": ""V�sterbotten"",
      ""boende"": ""G�rd"",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""gaffeltruckf�rare"",
      ""relstatus"": ""exklusiv s�rbo"",
      ""partnerinfo"": ""boel"",
      ""barnAntal"": """",
      ""barnBoende"": """",
      ""husdjur"": ""husdjur"",
      ""Hund"": """",
      ""Katt"": """",
      ""F�gel"": """",
      ""H�st"": ""H�st"",
      ""Annat"": ""mullvad"",
      ""stad"": ""Sm�stad"",
      ""stadAlternativ"": """",
      ""Skog"": ""Skog"",
      ""Hav"": """",
      ""Kultur"": """",
      ""Shopping"": ""Shopping"",
      ""bil"": """",
      ""bilinfo"": """",
      ""barn"": """",
      ""fritidsintressen"": ""m�lar naglarna, r�ker pipa, knypplar "",
      ""presentation"": ""jag �r en glad prick i sina b�sta �r. men jag saknar inte djup! nu �r jag p� jakt efter en sj�lsfr�nde att loda avgrunden med."",
      ""�lder"": ""58"",
      ""k�n"": ""Annat"",
      ""publicerad"": true,
      ""enddate"": ""2024-03-26"",
      ""userId"": ""b456"",
      ""endTimestamp"": 1711411200000
    },
    {
      ""id"": ""16fd"",
      ""rubrik"": ""fwd"",
      ""l�n"": ""Kalmar"",
      ""boende"": ""G�rd"",
      ""boendeAnnat"": """",
      ""syssels�ttning"": ""w4eradserfsed"",
      ""relstatus"": """",
      ""partnerinfo"": """",
      ""barnAntal"": """",
      ""barnBoende"": """",
      ""husdjur"": """",
      ""Hund"": """",
      ""Katt"": """",
      ""F�gel"": """",
      ""H�st"": """",
      ""Annat"": """",
      ""stad"": ""Mellanstor stad"",
      ""stadAlternativ"": """",
      ""Skog"": """",
      ""Hav"": ""Hav / Sj�"",
      ""Kultur"": """",
      ""Shopping"": """",
      ""bil"": """",
      ""bilinfo"": """",
      ""barn"": """",
      ""fritidsintressen"": ""gresfd"",
      ""presentation"": ""wfde"",
      ""�lder"": ""20"",
      ""k�n"": ""Annat"",
      ""publicerad"": true,
      ""enddate"": ""2024-04-25"",
      ""userId"": ""b456"",
      ""endTimestamp"": 1714003200000,
      ""bids"": [
        ""b456""
      ]
    }
  ]"
  );

app.MapPost("/users", () => @"
[
    {
      ""id"": ""1"",
      ""username"": ""rosa_parks"",
      ""email"": ""rosa.parks@example.com"",
      ""password"": ""bus"",
      ""role"": ""user""
    },
    {
      ""id"": ""2"",
      ""username"": ""malala_yousafzai"",
      ""email"": ""malala.yousafzai@example.com"",
      ""password"": ""nobelpeaceprize"",
      ""role"": ""admin""
    },
    {
      ""id"": ""3"",
      ""username"": ""emma_watson"",
      ""email"": ""emma.watson@example.com"",
      ""password"": ""heforshe"",
      ""role"": ""user""
    },
    {
      ""id"": ""4"",
      ""username"": ""bell_hooks"",
      ""email"": ""bell.hooks@example.com"",
      ""password"": ""feministtheory"",
      ""role"": ""user""
    },
    {
      ""id"": ""5"",
      ""username"": ""sojourner_truth"",
      ""email"": ""sojourner.truth@example.com"",
      ""password"": ""aintiawoman"",
      ""role"": ""admin""
    },
    {
      ""id"": ""63b0"",
      ""username"": ""aagrg"",
      ""email"": ""erik.cronqvist@gmail.com"",
      ""password"": ""aefaef""
    },
    {
      ""id"": ""8dde"",
      ""username"": ""aaga"",
      ""email"": ""erik.cronqvist@gmail.com"",
      ""password"": ""gagaga"",
      ""role"": ""user""
    },
    {
      ""id"": ""e712"",
      ""username"": ""bauta"",
      ""email"": ""efeo@geo.com"",
      ""password"": ""oioioioi"",
      ""role"": ""user""
    },
    {
      ""id"": ""ad58"",
      ""username"": ""micke"",
      ""email"": ""mikaelfant@gmail.com"",
      ""password"": ""123"",
      ""role"": ""user""
    },
    {
      ""id"": ""8224"",
      ""username"": ""fefefef"",
      ""email"": ""erik.cronqvist@gmail.com"",
      ""password"": ""efe"",
      ""role"": ""user""
    },
    {
      ""id"": ""0150"",
      ""username"": ""micke"",
      ""email"": ""mikaelfant@gmail.com"",
      ""password"": ""123"",
      ""role"": ""user""
    },
    {
      ""id"": ""d4fe"",
      ""username"": ""micke2"",
      ""email"": ""mikaelfant@gmail.com"",
      ""password"": ""1212"",
      ""role"": ""user""
    },
    {
      ""id"": ""b456"",
      ""username"": ""brillinat_emma"",
      ""email"": ""emma@trinket.us"",
      ""password"": ""wow"",
      ""role"": ""user""
    },
    {
      ""id"": ""4dfc"",
      ""username"": ""idiot"",
      ""email"": ""apa@gmail.com"",
      ""password"": ""q"",
      ""role"": ""user""
    }
  ]"
);



app.Run("http://localhost:3001");
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
