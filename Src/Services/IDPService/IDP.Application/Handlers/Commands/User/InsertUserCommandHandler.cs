using AutoMapper;
using IDP.Application.Commands.User;
using IDP.Domain.IRepository.Commands;
using MediatR;

namespace IDP.Application.Handlers.Commands.User;

public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public InsertUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<bool> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.Insert(new Domain.Entities.User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            NationalCode = request.NationalCode,
            BirthDate = request.BirthDate,
            Gender = request.Gender,
        });
        return true;
    }
}
