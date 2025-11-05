using Application.Contracts;
using Application.Contracts.Repositories;
using Infrastructure.Spotify.Model;

namespace Application.Services;

public class SpotifyAuthorizationService(
    ISpotifyAuthorization spotifyAuthorization,
    IAuthorizationRepository authorizationRepository)
{
    public async Task RetrieveAccessTokenAsync(string code, string redirectUri)
    {
        string accessToken = await spotifyAuthorization.RetrieveAccessTokenAsync(code, redirectUri);
        await authorizationRepository.SaveAccessTokenAsync(accessToken);
    }

    public AuthorizationUrl GetAuthorizationUrlAsync(string redirectUri)
    {
        return spotifyAuthorization.GetAuthorizationUrlAsync(redirectUri);
    }
}