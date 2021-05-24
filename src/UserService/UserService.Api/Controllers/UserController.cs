using UserService.Application.Commands.Contract;
using UserService.Application.Commands.InsertUser;
using UserService.Application.Commands.InsertUserAddress;
using UserService.Application.Queries.GetUserBalance;
using UserService.Application.Queries.GetUserExtract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Inserir um novo usuário
        /// </summary>
        /// <response code="200">Cadastrado com sucesso.</response>
        /// <response code="400">Dados existentes.</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] InsertUserInputModel request)
        {
            ICommandResult<int> commandResult = await _mediator.Send(request);
            return StatusCode((int)commandResult.httpStatusCode, commandResult);
        }

        /// <summary>
        /// Inserir um novo endereço para o usuário
        /// </summary>
        /// <response code="201">Endereço cadastrado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        public async Task<IActionResult> InsertAddress([FromBody] InsertUserAddressInputModel request)
        {
            ICommandResult<int> commandResult = await _mediator.Send(request);
            return StatusCode((int)commandResult.httpStatusCode, commandResult);
        }

        /// <summary>
        /// Obter quantidade de pontos atual do usuário
        /// </summary>
        /// <response code="200">Dados obtidos com sucesso.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public async Task<IActionResult> GetPointsBalance([FromQuery] GetUserBalanceInputModel request)
        {
            decimal response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// Obter extrato em um periodo de datas
        /// </summary>
        /// <response code="200">Dados obtidos com sucesso.</response>
        /// <response code="204">Não há itens.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public async Task<IActionResult> GetExtract([FromQuery] GetUserExtractInputModel request)
        {
            List<GetUserExtractViewModel> response = await _mediator.Send(request);

            if (response.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}
