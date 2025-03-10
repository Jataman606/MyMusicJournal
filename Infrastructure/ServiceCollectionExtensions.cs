using Domain.Interfaces;
using Infrastructure.Dao;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IAlbumDao, AlbumDao>();
    }
}