using Domain.Entities;
using Domain.Types;

namespace Application.Contracts.Repositories;

public interface IAlbumRepository
{
    Task<List<Album>> GetAllAsync();
    Task AddAsync(Album album);
    Task RateAlbum(Guid albumId, Rating rating);
}
