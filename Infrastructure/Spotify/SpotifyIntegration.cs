using Application.Contracts;
using Domain.Entities;

namespace Infrastructure.Spotify;

public class SpotifyIntegration : IAlbumSearchService
{   
    public Task<List<Album>> SearchAlbums(string searchTerm)
    {
        throw new NotImplementedException();
    }
}