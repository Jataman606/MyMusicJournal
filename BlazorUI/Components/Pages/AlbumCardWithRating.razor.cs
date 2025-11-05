using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Components.Pages;

public partial class AlbumCardWithRating
{
    [Inject] public AlbumsService AlbumsService { get; set; } = null!;
    [Parameter] public Album Album { get; set; } = new();

    private async Task SetRatingAsync(int i)
    {
        await AlbumsService.RateAlbumAsync(Album.Id, i);
    }
}