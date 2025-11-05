namespace Infrastructure.Spotify.Responses;

public class RetrieveAccessTokenResponse
{
    public string AccessToken { get; set; } = null!;
    
    public string TokenType { get; set; } = "Bearer";
    
    public string Scope { get; set; } = null!;
    
    public int ExpiresIn { get; set; }
    
    public string RefreshToken { get; set; } = null!;
}