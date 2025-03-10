using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class MyMusicJournalDbContext : DbContext
{
    public DbSet<Album> Albums { get; set; }

    private string DbFilePath { get; }

    public MyMusicJournalDbContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        DbFilePath = Path.Combine(path, "MusicJournal.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbFilePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyMusicJournalDbContext).Assembly);
    }
}