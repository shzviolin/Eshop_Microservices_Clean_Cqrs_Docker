using Auth;
using MediatR;

namespace IDP.Application.Queries.Auth;

public record AuthQuery : IRequest<JsonWebToken>
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
