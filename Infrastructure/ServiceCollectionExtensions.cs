using Domain.AlbumAggregate;
using Domain.Interfaces;
using Infrastructure.Ef;
using Infrastructure.Spotify;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IAlbumRepository, AlbumRepository>();
        services.AddTransient<IAlbumSearchService, SpotifyIntegration>();
    }
}