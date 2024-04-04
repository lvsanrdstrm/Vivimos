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
      ""headline"": ""Frihet & fantasi"",
      ""county"": ""Halland"",
      ""dwelling"": ""Lägenhet"",
      ""dwellingOther"": """",
      ""occupation"": ""Mellanchef"",
      ""relStatus"": ""ensamvarg"",
      ""partnerInfo"": """",
      ""childrenNum"": """",
      ""childrenHome"": """",
      ""pets"": true,
      ""dog"": false,
      ""cat"": true,
      ""bird"": false,
      ""horse"": false,
      ""other"": ""Gris"",
      ""city"": ""Mellanstor stad"",
      ""cityAlternative"": """",
      ""forest"": false,
      ""sea"": false,
      ""culture"": false,
      ""shopping"": true,
      ""car"": true,
      ""carInfo"": ""Ford Taunus"",
      ""children"": false,
      ""hobbies"": """",
      ""presentation"": ""Tjolahopp"",
      ""age"": ""18"",
      ""gender"": ""Man"",
      ""adActive"": true,
      ""endDate"": ""2024-04-30"",
      ""userId"": ""8224"",
      ""endTimestamp"": 1714435200000
    },
    {
      ""id"": ""b4ed"",
      ""headline"": ""Enkelhet och lugn & ro på landet!"",
      ""county"": ""Skåne"",
      ""dwelling"": ""Husvagn"",
      ""dwellingOther"": """",
      ""occupation"": ""sjukpensionär"",
      ""relStatus"": ""ensamvarg"",
      ""partnerInfo"": """",
      ""childrenNum"": """",
      ""childrenHome"": """",
      ""pets"": true,
      ""dog"": false,
      ""cat"": false,
      ""bird"": false,
      ""horse"": false,
      ""other"": ""två illrar"",
      ""city"": ""Bystan"",
      ""cityAlternative"": """",
      ""forest"": true,
      ""sea"": true,
      ""culture"": false,
      ""shopping"": false,
      ""car"": false,
      ""carInfo"": """",
      ""children"": false,
      ""hobbies"": ""fiskar, plockar bär och svamp, virkar, trippar"",
      ""presentation"": ""Tjoflöjt"",
      ""age"": ""54"",
      ""gender"": ""Kvinna"",
      ""adActive"": true,
      ""endDate"": """",
      ""userId"": """",
      ""endTimestamp"": null
    },
    {
      ""id"": ""a807"",
      ""headline"": ""Gay äldre lyx&kulturman"",
      ""county"": ""Stockholm"",
      ""dwelling"": ""Lägenhet"",
      ""dwellingOther"": """",
      ""occupation"": ""pensionär"",
      ""relStatus"": ""singel"",
      ""partnerInfo"": """",
      ""childrenNum"": """",
      ""childrenHome"": """",
      ""pets"": false,
      ""dog"": false,
      ""cat"": false,
      ""bird"": false,
      ""horse"": false,
      ""other"": """",
      ""city"": ""Storstad"",
      ""cityAlternative"": ""Centralt"",
      ""forest"": false,
      ""sea"": false,
      ""culture"": true,
      ""shopping"": true,
      ""car"": false,
      ""carInfo"": """",
      ""children"": false,
      ""hobbies"": ""raggar unga män, går på opera, äter dyrt, promenerar på Djurgården"",
      ""presentation"": ""tjiipppi"",
      ""age"": ""77"",
      ""gender"": ""Man"",
      ""adActive"": true,
      ""endDate"": """",
      ""userId"": """",
      ""endTimestamp"": null
    },
    {
      ""id"": ""ee84"",
      ""headline"": ""Zombielycka"",
      ""county"": ""Blekinge"",
      ""dwelling"": ""Villa"",
      ""dwellingOther"": """",
      ""occupation"": ""Hemmafru"",
      ""relStatus"": ""exklusiv sambo"",
      ""partnerInfo"": ""44"",
      ""childrenNum"": """",
      ""childrenHome"": """",
      ""pets"": false,
      ""dog"": false,
      ""cat"": false,
      ""bird"": false,
      ""horse"": false,
      ""other"": """",
      ""city"": ""Småstad"",
      ""cityAlternative"": """",
      ""forest"": true,
      ""sea"": false,
      ""culture"": false,
      ""shopping"": true,
      ""car"": false,
      ""carInfo"": """",
      ""children"": false,
      ""hobbies"": ""Sover, äter benso"",
      ""presentation"": ""flipflip"",
      ""age"": ""33"",
      ""gender"": ""Kvinna"",
      ""adActive"": true,
      ""endDate"": """",
      ""userId"": """",
      ""endTimestamp"": null
    },
    {
      ""id"": ""c07d"",
      ""headline"": ""This is it"",
      ""county"": ""Västerbotten"",
      ""dwelling"": ""Husvagn"",
      ""dwellingOther"": """",
      ""occupation"": ""brandman"",
      ""relStatus"": ""öppen särbo"",
      ""partnerInfo"": ""britta 48"",
      ""childrenNum"": """",
      ""childrenHome"": """",
      ""pets"": """",
      ""dog"": """",
      ""cat"": """",
      ""bird"": """",
      ""horse"": """",
      ""other"": """",
      ""city"": ""Småstad"",
      ""cityAlternative"": """",
      ""forest"": """",
      ""sea"": ""Hav / Sjö"",
      ""culture"": """",
      ""shopping"": """",
      ""car"": """",
      ""carInfo"": """",
      ""children"": """",
      ""hobbies"": ""spelar poker"",
      ""presentation"": ""Do you want to eat ice cream?"",
      ""age"": ""37"",
      ""gender"": ""Kvinna"",
      ""adActive"": true,
      ""endDate"": ""2024-04-30"",
      ""userId"": ""8224"",
      ""endTimestamp"": 1714435200000
    },
    {
      ""id"": ""62e0"",
      ""headline"": ""Frihet & fantasi"",
      ""county"": ""Skåne"",
      ""dwelling"": ""Lägenhet"",
      ""dwellingOther"": """",
      ""occupation"": ""studerande"",
      ""relStatus"": ""exklusiv särbo"",
      ""partnerInfo"": """",
      ""childrenNum"": ""1"",
      ""childrenHome"": ""Delvis"",
      ""pets"": """",
      ""dog"": """",
      ""cat"": """",
      ""bird"": """",
      ""horse"": """",
      ""other"": """",
      ""city"": ""Storstad"",
      ""cityAlternative"": """",
      ""forest"": """",
      ""sea"": ""Hav / Sjö"",
      ""culture"": ""Kultur"",
      ""shopping"": ""Shopping"",
      ""car"": ""bil"",
      ""carInfo"": ""Mercedes"",
      ""children"": ""barn"",
      ""hobbies"": ""Spelar musik, lyssnar på musik, mm"",
      ""presentation"": ""Programmeringsstuderande 52-årig separerad  kulturman (utgiven romanförfattare, översättare) med sär­begåvad varannanhelgsdotter och frispråkig, sexglad (kvinnlig) ingenjörssärbo, samt sällanrepande improvisationskrautband. Familjefritt boende i centrala Malmö."",
      ""age"": ""52"",
      ""gender"": ""Man"",
      ""adActive"": true,
      ""endDate"": ""2024-03-30"",
      ""userId"": ""d4fe"",
      ""endTimestamp"": 1711756800000
    },
    {
      ""id"": ""6d36"",
      ""headline"": ""efw"",
      ""county"": """",
      ""dwelling"": """",
      ""dwellingOther"": """",
      ""occupation"": ""sd"",
      ""relStatus"": """",
      ""partnerInfo"": """",
      ""childrenNum"": """",
      ""childrenHome"": """",
      ""pets"": """",
      ""dog"": """",
      ""cat"": """",
      ""bird"": """",
      ""horse"": """",
      ""other"": """",
      ""city"": """",
      ""cityAlternative"": """",
      ""forest"": """",
      ""sea"": """",
      ""culture"": """",
      ""shopping"": """",
      ""car"": """",
      ""carInfo"": """",
      ""children"": """",
      ""hobbies"": ""wed"",
      ""presentation"": ""wd"",
      ""age"": """",
      ""gender"": """",
      ""adActive"": false,
      ""endDate"": """",
      ""userId"": ""b456"",
      ""endTimestamp"": null
    },
    {
      ""id"": ""50e6"",
      ""headline"": ""vardagsromantism vid en sjö"",
      ""county"": ""Blekinge"",
      ""dwelling"": ""Husvagn"",
      ""dwellingOther"": """",
      ""occupation"": ""vävare"",
      ""relStatus"": ""knasigt"",
      ""partnerInfo"": """",
      ""childrenNum"": """",
      ""childrenHome"": """",
      ""pets"": ""husdjur"",
      ""dog"": """",
      ""cat"": """",
      ""bird"": ""Fågel"",
      ""horse"": """",
      ""other"": ""möss"",
      ""city"": ""Bystan"",
      ""cityAlternative"": """",
      ""forest"": """",
      ""sea"": ""Hav / Sjö"",
      ""culture"": ""Kultur"",
      ""shopping"": """",
      ""car"": """",
      ""carInfo"": """",
      ""children"": """",
      ""hobbies"": ""drömmer och skriver dikter"",
      ""presentation"": ""jag är en modern version av lord byron. take it or leave it."",
      ""age"": ""22"",
      ""gender"": ""Man"",
      ""adActive"": true,
      ""endDate"": ""2024-03-30"",
      ""userId"": ""b456"",
      ""endTimestamp"": 1711756800000
    },
    {
      ""id"": ""b816"",
      ""headline"": ""djupa suckar och höga stämningar"",
      ""county"": ""Västerbotten"",
      ""dwelling"": ""Gård"",
      ""dwellingOther"": """",
      ""occupation"": ""gaffeltruckförare"",
      ""relStatus"": ""exklusiv särbo"",
      ""partnerInfo"": ""boel"",
      ""childrenNum"": """",
      ""childrenHome"": """",
      ""pets"": ""husdjur"",
      ""dog"": """",
      ""cat"": """",
      ""bird"": """",
      ""horse"": ""Häst"",
      ""other"": ""mullvad"",
      ""city"": ""Småstad"",
      ""cityAlternative"": """",
      ""forest"": ""Skog"",
      ""sea"": """",
      ""culture"": """",
      ""shopping"": ""Shopping"",
      ""car"": """",
      ""carInfo"": """",
      ""children"": """",
      ""hobbies"": ""målar naglarna, röker pipa, knypplar"",
      ""presentation"": ""jag är en glad prick i sina bästa år. men jag saknar inte djup! nu är jag på jakt efter en själsfrände att loda avgrunden med."",
      ""age"": ""58"",
      ""gender"": ""Annat"",
      ""adActive"": true,
      ""endDate"": ""2024-03-26"",
      ""userId"": ""b456"",
      ""endTimestamp"": 1711411200000
    },
    {
      ""id"": ""16fd"",
      ""headline"": ""fwd"",
      ""county"": ""Kalmar"",
      ""dwelling"": ""Gård"",
      ""dwellingOther"": """",
      ""occupation"": ""w4eradserfsed"",
      ""relStatus"": """",
      ""partnerInfo"": """",
      ""childrenNum"": """",
      ""childrenHome"": """",
      ""pets"": """",
      ""dog"": """",
      ""cat"": """",
      ""bird"": """",
      ""horse"": """",
      ""other"": """",
      ""city"": ""Mellanstor stad"",
      ""cityAlternative"": """",
      ""forest"": """",
      ""sea"": ""Hav / Sjö"",
      ""culture"": """",
      ""shopping"": """",
      ""car"": """",
      ""carInfo"": """",
      ""children"": """",
      ""hobbies"": ""gresfd"",
      ""presentation"": ""wfde"",
      ""age"": ""20"",
      ""gender"": ""Annat"",
      ""adActive"": true,
      ""endDate"": ""2024-04-25"",
      ""userId"": ""b456"",
      ""endTimestamp"": 1714003200000
    }
  ]
"
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
