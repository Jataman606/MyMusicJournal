using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Spotify;

public class SpotifyIntegration : IAlbumSearchService
{
    public Task<List<Album>> SearchAlbums(string searchTerm)
    {
        throw new NotImplementedException();
    }
}