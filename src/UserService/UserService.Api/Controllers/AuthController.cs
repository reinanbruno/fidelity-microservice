using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using UserService.Application.Commands.Authenticate;
using UserService.Application.Commands.Contract;

namespace UserService.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Autenticar usuário
        /// </summary>
        /// <response code="200">Autenticado com sucesso.</response>
        /// <response code="404">Usuário não autenticado.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserInputModel request)
        {
            ICommandResult<string> commandResult = await _mediator.Send(request);
            return StatusCode((int)commandResult.httpStatusCode, commandResult);
        }
    }
}
