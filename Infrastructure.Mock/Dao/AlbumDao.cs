using Domain.Entities;
using Domain.Enums;
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
        album = new Album
        {
            Id = Guid.NewGuid(),
            Name = "Heartbreaks & 808s",
            Artist = "Kanye West",
            SpotifyId = "123456789",
            ImageUrl = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",
            Genre = Genre.HipHop,
            UserRating = new Rating(5)
        };

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