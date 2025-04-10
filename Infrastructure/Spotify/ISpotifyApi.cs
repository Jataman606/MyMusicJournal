using Infrastructure.Spotify.Requests;
using Refit;

namespace Infrastructure.Spotify;

public interface ISpotifyApi
{
    [Get("/authorize")]
    public Task AuthorizeAsync(AuthorizeRequest request);
}