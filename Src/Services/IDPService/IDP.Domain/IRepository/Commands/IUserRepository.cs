using IDP.Domain.Entities;

namespace IDP.Domain.IRepository.Commands;

public interface IUserRepository
{
    Task<bool> Insert(User user);
}
