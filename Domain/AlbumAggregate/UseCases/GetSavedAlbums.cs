using Domain.Entities;

namespace Domain.AlbumAggregate.UseCases;

public class GetSavedAlbums(IAlbumRepository repository)
{
    public async Task<IEnumerable<Album>> Execute()
    {
        return await repository.GetAllAsync();
    }
}