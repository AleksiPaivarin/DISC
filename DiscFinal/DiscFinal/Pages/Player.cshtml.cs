using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Newtonsoft.Json;

namespace YourNamespace.Pages
{
    public class PlayerModel : PageModel
    {
        private readonly BungieApiClient _bungieApiClient;

        public PlayerModel(BungieApiClient bungieApiClient)
        {
            _bungieApiClient = bungieApiClient;
        }

        public async Task OnGetAsync(string playerName)
        {
            PlayerInfoResponse playerResponse = await _bungieApiClient.GetPlayerInfoAsync(playerName);
            PlayerData = playerResponse?.Players.FirstOrDefault(); // No CS0029 error now
        }


        public PlayerInfoResponse PlayerData { get; set; }

        public void OnGet()
        {
            // Code to fetch and populate PlayerData
        }
    }
}
