namespace Infrastructure.Spotify.Requests;

public class AuthorizeRequest
{
    public string ClientId { get; set; }
    public string ResponseType = "code";
    public string RedirectUri { get; set; }
    public string Scopes { get; set; }
    public string State { get; set; }
    public string CodeChallenge { get; set; }
    public string CodeChallengeMethod = "S256";
}