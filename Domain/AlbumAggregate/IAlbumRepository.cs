using Domain.Entities;
using Domain.Types;

namespace Domain.AlbumAggregate;

public interface IAlbumRepository
{
    Task<List<Album>> GetAllAsync();
    Task AddAsync(Album album);
    Task RateAlbum(Guid albumId, Rating rating);
}
