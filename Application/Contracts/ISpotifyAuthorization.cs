using Infrastructure.Spotify.Model;

namespace Application.Contracts;

public interface ISpotifyAuthorization
{
    AuthorizationUrl GetAuthorizationUrlAsync(string redirectUri);
    Task<string> RetrieveAccessTokenAsync(string code, string redirectUri);
}