
using Newtonsoft.Json;

public class BungieApiClient
{
    private const string API = "2fe7354686ed4b60834bc601bc7dc012";
    private readonly HttpClient _httpClient;

    public BungieApiClient(string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add(API, apiKey);
    }

    public async Task<string?> GetPlayerInfoAsync(string playerName)
    {
        string apiUrl = $"https://www.bungie.net/Platform{playerName}/";
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
    public required List<PlayerData> Players { get; set; }
    public class PlayerData
    {
        [JsonProperty("membershipId")]
        public required string MembershipId { get; set; }

        // Add other properties as needed
    }
}

