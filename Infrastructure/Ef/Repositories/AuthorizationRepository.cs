using Application.Contracts.Repositories;

namespace Infrastructure.Ef.Repositories;

public class AuthorizationRepository : IAuthorizationRepository
{
    public Task SaveAccessTokenAsync(string accessToken)
    {
        throw new NotImplementedException();
    }
}