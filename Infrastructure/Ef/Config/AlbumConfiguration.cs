using Domain.Entities;
using Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Ef.Config;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Name)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(e => e.Artist)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(e => e.ImageUrl)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(e => e.SpotifyId)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.UserRating)
            .HasConversion(
                v => (short)v,
                v => new Rating(v));
        builder.Property(e => e.Genre).HasConversion<string>();

    }
}