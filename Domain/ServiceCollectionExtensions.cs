using Domain.AlbumAggregate.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class ServiceCollectionExtensions
{
    public static void AddDomainUseCases(this IServiceCollection services)
    {
        services.AddAlbumAggregateUseCases();
    }
}