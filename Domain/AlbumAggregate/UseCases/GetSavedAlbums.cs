using Domain.Entities;

namespace Domain.AlbumAggregate.UseCases;

public class GetSavedAlbums(IAlbumRepository repository)
{
    public async Task<List<Album>> ExecuteAsync()
    {
        return await repository.GetAllAsync();
    }
}