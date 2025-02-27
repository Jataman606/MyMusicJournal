using Domain.Entities;
using Domain.Types;

namespace Domain.Interfaces;

public interface IAlbumDao
{
    Task<List<Album>> GetAllAsync();
    Task AddAsync(Album album);
    Task RateAlbum(Guid albumId, Rating rating);
}
