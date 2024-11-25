using Asp.Versioning;
using IDP.Api.Controllers.BaseController;
using IDP.Application.Queries.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IDP.Api.Controllers.V1
{
    [ApiVersion(1)]
    [ApiVersion(2)]
    [ApiController]
    [Route("api/v{v:apiVersion}/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthQuery authQuery)
        {
            var result = await _mediator.Send(authQuery);
            return Ok(result);
        }
    }
}
