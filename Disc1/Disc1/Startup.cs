using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<BungieApiClient>(new BungieApiClient("2fe7354686ed4b60834bc601bc7dc012"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run(async context =>
{
    var bungieApiClient = context.RequestServices.GetRequiredService<BungieApiClient>();

    string playerName = "playerName";
    var playerInfo = await bungieApiClient.GetPlayerInfoAsync(playerName);

    if (playerInfo != null && playerInfo.Players.Count > 0)
    {
        foreach (var player in playerInfo.Players)
        {
            Console.WriteLine($"Membership ID: {player.MembershipId}");
            // Add more property printing as needed
        }
    }
    else
    {
        Console.WriteLine("Player not found or an error occurred while retrieving data.");
    }
});

app.Run();
