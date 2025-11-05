using Application.Contracts;
using Application.Contracts.Repositories;
using Infrastructure.Ef.Repositories;
using Infrastructure.Spotify;

namespace BlazorUI;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ISpotifyAuthorization, SpotifyAuthorization>();
        services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
    }
}