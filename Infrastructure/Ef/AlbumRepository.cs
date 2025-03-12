using Domain.AlbumAggregate;
using Domain.Entities;
using Domain.Types;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class AlbumRepository(MyMusicJournalDbContext dbContext) : IAlbumRepository
{
    public async Task<List<Album>> GetAllAsync()
    {
        // return await dbContext.Albums.ToListAsync();
        return new()
        {
            new Album {Name = "Test Album1", Artist = "Test Artist", ImageUrl = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228"},
            new Album {Name = "Test Album2", Artist = "Test Artist", ImageUrl = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228"},
            new Album {Name = "Test Album3", Artist = "Test Artist", ImageUrl = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228"}
        };
    }

    public async Task AddAsync(Album album)
    {
        dbContext.Albums.Add(album);
        await dbContext.SaveChangesAsync();
    }

    public async Task RateAlbum(Guid albumId, Rating rating)
    {
        Album? album = await dbContext.Albums.FindAsync(albumId);
        if (album == null)
        {
            throw new KeyNotFoundException($"Album with id {albumId} not found");
        }
        
        album.UserRating = rating;
        await dbContext.SaveChangesAsync();
    }
}