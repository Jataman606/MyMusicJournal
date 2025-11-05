using Domain.Entities;

namespace Application.Contracts;

public interface IAlbumSearchService
{
    Task<List<Album>> SearchAlbums(string searchTerm);
}