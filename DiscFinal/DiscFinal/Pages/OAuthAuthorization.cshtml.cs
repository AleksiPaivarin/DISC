using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class OAuthAuthorizationModel : PageModel
{
    private readonly OAuthService _oauthService;

    public OAuthAuthorizationModel(OAuthService oauthService)
    {
        _oauthService = oauthService;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public string GetAuthorizationUrl()
    {
        return _oauthService.GetAuthorizationUrl(_oauthService.Get_configuration());
    }
}

