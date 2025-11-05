using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Web;
using Application.Contracts;
using Infrastructure.Spotify.Model;
using Infrastructure.Spotify.Requests;
using Infrastructure.Spotify.Responses;

namespace Infrastructure.Spotify;

public class SpotifyAuthorization(SpotifyConfigurationOptions options, ISpotifyApi spotifyApi) : ISpotifyAuthorization
{
    static string? _codeVerifier;
    
    public AuthorizationUrl GetAuthorizationUrlAsync(string redirectUri)
    {
        Uri authUrl = new("https://accounts.spotify.com/authorize");
        
        // https://developer.spotify.com/documentation/web-api/tutorials/code-pkce-flow
        _codeVerifier = GenerateRandomString();
        byte[] codeVerifierBytes = System.Text.Encoding.Unicode.GetBytes(_codeVerifier);
        byte[] hash = SHA256.HashData(codeVerifierBytes);
        string codeChallenge = Convert.ToBase64String(hash);
        string[] scopes =
        [
            "user-read-playback-state", 
            "user-modify-playback-state",
            "user-read-currently-playing",
            "playlist-read-private",
            "playlist-modify-private",
            "user-read-playback-position",
            "user-top-read",
            "user-read-recently-played",
            "user-library-read"
        ];
        
        Dictionary<string, string> parameters = new()
        {
            { "response_type", "code" },
            { "client_id", options.ClientId },
            { "scope", string.Join(' ', scopes) },
            { "code_challenge_method", "S256" },
            { "code_challenge", codeChallenge },
            { "redirect_uri", redirectUri }
        };

        // Build query string
        NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
        foreach (KeyValuePair<string, string> param in parameters)
        {
            queryString[param.Key] = param.Value;
        }

        // Create final URL
        var builder = new UriBuilder(authUrl);
        builder.Query = queryString.ToString();

        AuthorizationUrl result = new(url: builder.ToString(), codeVerifier: _codeVerifier);

        return result;
    }

    public async Task<string> RetrieveAccessTokenAsync(string code, string redirectUri)
    {
        if (_codeVerifier == null)
        {
            throw new ApplicationException("Code verifier is null");
        }
        
        RetrieveAccessTokenRequest request = new()
        {
            Code = code,
            RedirectUri = redirectUri,
            ClientId = options.ClientId,
            CodeVerifier = _codeVerifier
        };

        RetrieveAccessTokenResponse response = await spotifyApi.RetrieveAccessTokenAsync(request);
        
        return response.AccessToken;
    }

    private static string GenerateRandomString()
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