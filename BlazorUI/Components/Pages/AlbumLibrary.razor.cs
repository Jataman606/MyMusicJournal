using Domain.AlbumAggregate.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Components.Pages;

public partial class AlbumLibrary
{
    [Inject]
    public GetSavedAlbums GetSavedAlbums { get; set; }= default!;

    private List<Album> library = new();

    protected override async Task OnInitializedAsync()
    { 
        await base.OnInitializedAsync();

        library = await GetSavedAlbums.ExecuteAsync();
    }
}