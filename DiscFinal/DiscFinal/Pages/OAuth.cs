using Microsoft.Extensions.Configuration;
using System;

public class OAuthService
{
    private readonly IConfiguration _configuration;

    public OAuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IConfiguration Get_configuration()
    {
        return _configuration;
    }

    public string GetAuthorizationUrl(IConfiguration _configuration)
    {
        string clientId = _configuration["45182"];
        string redirectUri = _configuration["https://localhost:7039/"];
        string authorizationEndpoint = _configuration["https://www.bungie.net/en/OAuth/Authorize"];

        string authorizationUrl = $"{authorizationEndpoint}?client_id={clientId}&redirect_uri={redirectUri}&response_type=code";

        return authorizationUrl;
    }
}
