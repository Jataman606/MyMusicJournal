using Domain.AlbumAggregate;
using Domain.Entities;
using Domain.Types;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class AlbumRepository(MyMusicJournalDbContext dbContext) : IAlbumRepository
{
    public async Task<List<Album>> GetAllAsync()
    {
        return await dbContext.Albums.ToListAsync();
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