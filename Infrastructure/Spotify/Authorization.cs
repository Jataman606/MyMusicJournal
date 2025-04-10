using System.Security.Cryptography;
using Infrastructure.Spotify.Requests;

namespace Infrastructure.Spotify;

public class Authorization(ISpotifyApi spotifyApi, SpotifyConfigurationOptions options)
{
    public async Task AuthorizeAsync()
    {
        // https://developer.spotify.com/documentation/web-api/tutorials/code-pkce-flow
        string randomString = GenerateRandomString();
        byte[] bytes = System.Text.Encoding.Unicode.GetBytes(randomString);
        byte[] hash = SHA256.HashData(bytes);
        string codeChallange = Convert.ToBase64String(hash);

        AuthorizeRequest request = new();
        request.ClientId = options.ClientId;
        request.CodeChallenge = codeChallange;
        request.RedirectUri = "www.google.com";
        request.Scopes = "profile";
        
        await spotifyApi.AuthorizeAsync(request);
    }

    private string GenerateRandomString()
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] randomString = new char[128];
        for (int index = 0; index < 128; index++)
        {
            int randomCharacterIndex = RandomNumberGenerator.GetInt32(128);
            randomString[index] = characters[randomCharacterIndex];
        }

        return new string(randomString);
    }
}