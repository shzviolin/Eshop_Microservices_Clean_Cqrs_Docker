using Auth;
using IDP.Application.Queries.Auth;
using MediatR;

namespace IDP.Application.Handlers.Queries.Auth;

public class AuthQueryHandler : IRequestHandler<AuthQuery, JsonWebToken>
{
    private readonly IJwtHandler _jwtHandler;

    public AuthQueryHandler(IJwtHandler jwtHandler)
    {
        _jwtHandler = jwtHandler;
    }
    public async Task<JsonWebToken> Handle(AuthQuery request, CancellationToken cancellationToken)
    {
        var token = _jwtHandler.Create(45);
        return token;
    }
}
