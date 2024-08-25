using IDP.Domain.Entities;
using IDP.Domain.IRepository.Commands.Base;

namespace IDP.Domain.IRepository.Commands;

public interface IUserCommandRepository : ICommandRepository<User>
{
}
