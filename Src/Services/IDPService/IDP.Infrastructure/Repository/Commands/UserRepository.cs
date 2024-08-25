using IDP.Domain.Entities;
using IDP.Domain.IRepository.Commands;

namespace IDP.Infrastructure.Repository.Commands;

public class UserRepository : IUserRepository
{
    public async Task<bool> Insert(User user)
    {
        return true;
    }
}
