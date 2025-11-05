using Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Spotify;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSpotifyIntegration(this IServiceCollection services)
    {
        services.AddTransient<ISpotifyAuthorization, SpotifyAuthorization>();
        services.AddTransient<IAlbumSearchService, SpotifyIntegration>();
        return services;
    }
}