using AutoMapper;
using IDP.Application.Commands.User;
using MediatR;

namespace IDP.Application.Handlers.Commands.User;

public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, bool>
{
    private readonly IMapper _mapper;

    public InsertUserCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }


    public async Task<bool> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        return true;
    }
}
