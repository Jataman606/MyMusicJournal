using Domain.Entities;
using Domain.Interfaces;

namespace Domain.AlbumAggregate.UseCases;

public class SearchAlbums(IAlbumSearchService albumSearchService)
{
    public async Task<IEnumerable<Album>> Execute(string searchTerm)
    {
        return await albumSearchService.SearchAlbums(searchTerm);
    }
}