using Domain.Entities;
using Domain.Interfaces;
using Domain.Types;

namespace Infrastructure.Dao;

public class AlbumDao : IAlbumDao
{
    public Task<List<Album>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Album album)
    {
        throw new NotImplementedException();
    }

    public Task RateAlbum(Guid albumId, Rating rating)
    {
        throw new NotImplementedException();
    }
}