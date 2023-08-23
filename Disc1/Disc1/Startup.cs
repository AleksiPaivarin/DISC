using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<BungieApiClient>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.UseAuthorization();

app.MapRazorPages();

app.Run();

{
static async Task Main(string[] args)
{
string apiKey = "2fe7354686ed4b60834bc601bc7dc012";
BungieApiClient bungieApiClient = new BungieApiClient(apiKey);

string playerName = "desiredPlayerName";
var playerInfo = await bungieApiClient.GetPlayerInfoAsync(playerName);
Console.WriteLine(playerInfo); // Display it as needed

Console.WriteLine("Open the following link in your browser:");
Console.WriteLine("https://www.bungie.net/");

// This ensures the console application doesn't exit immediately
Console.ReadLine();
}
}

public class BungieApiClient
{
    private const string API = "2fe7354686ed4b60834bc601bc7dc012";
    private readonly HttpClient _httpClient;

    public BungieApiClient(string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("2fe7354686ed4b60834bc601bc7dc012", apiKey);
    }

    public async Task<string?> GetPlayerInfoAsync(string playerName)
    {
        string apiUrl = $"https://www.bungie.net/Platform/Destiny2/SearchDestinyPlayer/-1/{playerName}/";
        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        return null;
    }
}

public class MyPlayerResponse
{
    [JsonProperty("Response")]
    public List<PlayerData> Players { get; set; }
}

public class PlayerData
{
    [JsonProperty("membershipId")]
    public string MembershipId { get; set; }

    // Add other properties as needed
}


