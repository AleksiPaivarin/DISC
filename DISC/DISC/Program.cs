
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "2fe7354686ed4b60834bc601bc7dc012";
        BungieApiClient bungieApiClient = new BungieApiClient(apiKey);

        string playerName = "desiredPlayerName";
        var playerInfo = await bungieApiClient.GetPlayerInfoAsync(playerName);
        Console.WriteLine(playerInfo); // or display it as needed

        // Add more code as necessary

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




public class PlayerResponse
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


