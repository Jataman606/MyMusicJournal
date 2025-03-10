using Domain.Entities;

namespace Domain.AlbumAggregate.UseCases;

public class AddAlbum(IAlbumRepository repository)
{
    public async Task Execute(Album album)
    {
        await repository.AddAsync(album);
    }
}