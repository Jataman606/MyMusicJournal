namespace Infrastructure.Spotify.Requests;

public class RetrieveAccessTokenRequest
{
    public string GrantType = "authorization_code";
    
    public string Code { get; set; } = null!;
    
    public string RedirectUri { get; set; } = null!;
    
    public string ClientId { get; set; } = null!;
    
    public string CodeVerifier { get; set; } = null!;
}