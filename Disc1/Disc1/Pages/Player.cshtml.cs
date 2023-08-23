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
            string playerInfo = await _bungieApiClient.GetPlayerInfoAsync(playerName);
            PlayerData = JsonConvert.DeserializeObject<MyPlayerResponse>(playerInfo);
        }

        public MyPlayerResponse PlayerData { get; private set; }
    }
}
