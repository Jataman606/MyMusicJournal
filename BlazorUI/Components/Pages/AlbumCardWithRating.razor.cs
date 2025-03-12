using Domain.AlbumAggregate.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Components.Pages;

public partial class AlbumCardWithRating
{
    [Inject] public RateAlbum RateAlbum { get; set; } = default!;
    [Parameter] public Album Album { get; set; } = new();

    private async Task SetRatingAsync(int i)
    {
        await RateAlbum.ExecuteAsync(Album.Id, i);
    }
}