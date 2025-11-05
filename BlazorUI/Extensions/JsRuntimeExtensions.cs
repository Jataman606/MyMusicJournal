using Microsoft.JSInterop;

namespace BlazorUI.Extensions;

public static class JsRuntimeExtensions
{
    public static async Task SetSessionValueAsync(this IJSRuntime jsRuntime, string key, string value)
        => await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", key, value);
    
    public static async Task<string> GetSessionValueAsync(this IJSRuntime jsRuntime, string key)
        => await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", key);
    
    public static async Task RemoveSessionValueAsync(this IJSRuntime jsRuntime, string key)
        => await jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", key);
}