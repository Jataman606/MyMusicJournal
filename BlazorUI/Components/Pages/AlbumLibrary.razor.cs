using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Components.Pages;

public partial class AlbumLibrary
{
    [Inject]
    public AlbumsService AlbumsService { get; set; }= default!;

    private List<Album> library = new();

    protected override async Task OnInitializedAsync()
    { 
        await base.OnInitializedAsync();

        library = await AlbumsService.GetSavedAlbumsAsync();
    }
}