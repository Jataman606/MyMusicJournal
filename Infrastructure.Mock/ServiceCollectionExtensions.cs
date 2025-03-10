using Domain.AlbumAggregate;
using Domain.Interfaces;
using Infrastructure.Mock.Dao;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mock;

public static class ServiceCollectionExtensions
{
    public static void AddMockInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IAlbumRepository, AlbumRepository>();
    }
}