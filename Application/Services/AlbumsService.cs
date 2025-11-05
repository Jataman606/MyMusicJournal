using Application.Contracts;
using Application.Contracts.Repositories;
using Domain.Entities;
using Domain.Types;

namespace Application.Services;

public class AlbumsService(IAlbumRepository repository, IAlbumSearchService albumSearchService)
{
    public async Task AddAlbumAsync(Album album)
    {
        await repository.AddAsync(album);
    }

    public async Task<List<Album>> GetSavedAlbumsAsync() 
    {
        return await repository.GetAllAsync();
    }

    public async Task RateAlbumAsync(Guid albumId, Rating rating)
    {
        await repository.RateAlbum(albumId, rating);
    }
    
    public async Task<IEnumerable<Album>> SearchAlbumsAsync(string searchTerm)
    {
        return await albumSearchService.SearchAlbums(searchTerm);
    }
}