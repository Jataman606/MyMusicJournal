using Domain.Entities;
using Domain.Interfaces;
using Domain.Types;

namespace Infrastructure.Mock.Dao;

public class AlbumDao : IAlbumDao
{
    static readonly List<Album> _albums = [];
    
    public Task<List<Album>> GetAllAsync()
    {
        return Task.FromResult(_albums);
    }

    public Task AddAsync(Album album)
    {
        _albums.Add(album);
        return Task.CompletedTask;
    }

    public Task RateAlbum(Guid albumId, Rating rating)
    {
        var album = _albums.Single(a => a.Id == albumId);
        album.UserRating = rating;
        return Task.CompletedTask;
    }
}