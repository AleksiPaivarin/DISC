using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class BungieApiClient
{
    private readonly HttpClient _httpClient;

    public BungieApiClient(string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
    }

    public async Task<PlayerInfoResponse?> GetPlayerInfoAsync(string playerName)
    {
        string apiUrl = $"https://www.bungie.net/Platform/Destiny2/SearchDestinyPlayer/-1/{playerName}/";

        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl); // Use the apiUrl here

        if (response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            var playerResponse = JsonConvert.DeserializeObject<PlayerInfoResponse>(responseString);
            return playerResponse;
        }

        return null;
    }

}

public class PlayerInfoResponse
{
    [JsonProperty("Response")]
    public required List<PlayerData> Players { get; set; }

    public static implicit operator PlayerInfoResponse?(PlayerData? v)
    {
        throw new NotImplementedException();
    }
}

public class PlayerData
{
    [JsonProperty("membershipId")]
    public required string MembershipId { get; set; }

    // Add other properties as needed

}

