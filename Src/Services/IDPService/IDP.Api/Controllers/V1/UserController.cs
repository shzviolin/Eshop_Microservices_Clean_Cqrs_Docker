using IDP.Api.Controllers.BaseController;
using IDP.Application.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IDP.Api.Controllers.V1
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : IBaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Inser user information
        /// </summary>
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] InsertUserCommand insertUserCommand)
        {
            ArgumentNullException.ThrowIfNull(insertUserCommand);

            var result = await _mediator.Send(insertUserCommand);
            return Ok(result);
        }
    }
}
