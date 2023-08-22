using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOUR_API_KEY";
        string membershipType = "YOUR_MEMBERSHIP_TYPE"; // Esim. "Steam"
        string membershipId = "YOUR_MEMBERSHIP_ID"; // Käyttäjän jäsenyystunnus
        string characterId = "YOUR_CHARACTER_ID"; // Hahmon tunnus

        string apiUrl = $"https://www.bungie.net/Platform/Destiny2/{membershipType}/Account/{membershipId}/Character/{characterId}/Stats/";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
