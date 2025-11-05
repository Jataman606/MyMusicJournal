using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Spotify.Model;

public class AuthorizationUrl
{
    public AuthorizationUrl()
    {
    }

    [SetsRequiredMembers]
    public AuthorizationUrl(string url, string codeVerifier)
    {
        Url = url;
        CodeVerifier = codeVerifier;
    }

    public required string Url { get; set; }
    public required string CodeVerifier { get; set; }
}