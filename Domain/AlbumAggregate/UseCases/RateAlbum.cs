using Domain.Types;

namespace Domain.AlbumAggregate.UseCases;

public class RateAlbum(IAlbumRepository repository)
{
    public async Task ExecuteAsync(Guid albumId, Rating rating)
    {
        await repository.RateAlbum(albumId, rating);
    }
}