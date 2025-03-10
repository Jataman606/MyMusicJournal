using Domain.AlbumAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ef;

public static class ServiceCollectionExtensions
{
    public static void AddEfInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<MyMusicJournalDbContext>();
        services.AddScoped<IAlbumRepository, AlbumRepository>();
    }
}