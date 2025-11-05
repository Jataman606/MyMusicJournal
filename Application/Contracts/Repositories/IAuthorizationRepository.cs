namespace Application.Contracts.Repositories;

public interface IAuthorizationRepository
{
    public Task SaveAccessTokenAsync(string accessToken);
}