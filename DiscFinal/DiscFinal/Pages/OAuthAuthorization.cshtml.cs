using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class OAuthAuthorizationModel : PageModel
{
    private readonly OAuthService _oauthService;

    public OAuthAuthorizationModel(OAuthService oauthService)
    {
        _oauthService = oauthService;
    }

    public string AuthorizationUrl => _oauthService.GetAuthorizationUrl(_oauthService.Get_configuration());

    // This method can be called when you want to make an API request
    public async Task<IActionResult> MakeApiRequestAsync()
    {
        using (var httpClient = new HttpClient())
        {
            var apiKey = "your_api_key_here";
            var apiUrl = "https://www.bungie.net/Platform/[your_endpoint]";

            // Add the X-API-Key header to the request
            httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);

            // Make your API request
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Process the response
                var content = await response.Content.ReadAsStringAsync();
                // ... process the content
            }
            else
            {
                // Handle error
                return StatusCode((int)response.StatusCode);
            }
        }

        return Page();
    }
}
