using Microsoft.Extensions.DependencyInjection;

namespace Domain.AlbumAggregate.UseCases;

public static class ServiceCollectionExtensions
{
    public static void AddAlbumAggregateUseCases(this IServiceCollection services)
    {
        services.AddTransient<GetSavedAlbums>();
    }
}