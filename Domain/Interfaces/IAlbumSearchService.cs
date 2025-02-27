using Domain.Entities;

namespace Domain.Interfaces;

public interface IAlbumSearchService
{
    Task<List<Album>> SearchAlbums(string searchTerm);
}