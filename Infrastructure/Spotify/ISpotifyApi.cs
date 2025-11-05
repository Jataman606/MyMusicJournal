using Infrastructure.Spotify.Requests;
using Infrastructure.Spotify.Responses;
using Refit;

namespace Infrastructure.Spotify;

public interface ISpotifyApi
{
    [Get("/authorize")]
    public Task AuthorizeAsync(AuthorizeRequest request);
    
    [Post("/api/token")]
    public Task<RetrieveAccessTokenResponse> RetrieveAccessTokenAsync(RetrieveAccessTokenRequest request);
}