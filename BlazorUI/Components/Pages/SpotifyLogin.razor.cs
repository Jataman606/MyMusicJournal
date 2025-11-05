using Application.Contracts;
using Application.Contracts.Repositories;
using Application.Services;
using BlazorUI.Extensions;
using Infrastructure.Spotify.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorUI.Components.Pages;

public partial class SpotifyLogin
{
    [Inject] private SpotifyAuthorizationService SpotifyAuthorization { get; set; } = null!;
    [Inject] private IJSRuntime JsRuntime { get; set; } = null!;
    
    [SupplyParameterFromQuery] private string? Code { get; set; }
    [SupplyParameterFromQuery] private string? State { get; set; }
    [SupplyParameterFromQuery] private string? Error { get; set; }
    private LoginState loginState { get; set; }

    private static string CodeVerifierSessionKey => "pkce_code_verifier";
    private async Task AuthorizeSpotifyAccess()
    {
        AuthorizationUrl sportifyAuthUrl = SpotifyAuthorization.GetAuthorizationUrlAsync(Navigation.Uri);
        await JsRuntime.SetSessionValueAsync(CodeVerifierSessionKey, sportifyAuthUrl.CodeVerifier);
        Navigation.NavigateTo(sportifyAuthUrl.Url, true);
    }

    private async Task ReceiveAccessTokenAsync()
    {
        try
        {
            string codeVerifier = await JsRuntime.GetSessionValueAsync(CodeVerifierSessionKey);
            await SpotifyAuthorization.RetrieveAccessTokenAsync(codeVerifier, Navigation.Uri);
            loginState = LoginState.AccessTokenReceived;
            
            await JsRuntime.RemoveSessionValueAsync(CodeVerifierSessionKey);
        }
        catch (Exception e)
        {
            Error = e.Message;
        }
    }
    
    private void InitLoginState()
    {
        if (Error != null)
        {
            loginState = LoginState.Error;
        }
        else if (Code != null)
        {
            loginState = LoginState.Authorized;
        }
        else
        {
            loginState = LoginState.Init;
        }
    }

    private enum LoginState
    {
        Init,
        Authorized,
        AccessTokenReceived,
        Error
    }
}