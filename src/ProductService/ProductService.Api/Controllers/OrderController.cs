using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Commands.Contract;
using ProductService.Application.Commands.InsertOrder;
using ProductService.Application.Queries.GetOrders;
using ProductService.Application.Queries.GetOrderTracking;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Inserir um novo pedido
        /// </summary>
        /// <response code="200">Cadastrado com sucesso.</response>
        /// <response code="400">Dados existentes.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] InsertOrderInputModel request)
        {
            ICommandResult<int> commandResult = await _mediator.Send(request);
            return StatusCode((int)commandResult.httpStatusCode, commandResult);
        }

        /// <summary>
        /// Consultar pedidos do usuário
        /// </summary>
        /// <response code="200">Dados obtidos com sucesso.</response>
        /// <response code="204">Não há itens.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrderInputModel request)
        {
            List<GetOrderViewModel> response = await _mediator.Send(request);

            if (response.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        /// <summary>
        /// Listar historico de rastreamento do pedido
        /// </summary>
        /// <response code="200">Dados obtidos com sucesso.</response>
        /// <response code="204">Não há itens.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public async Task<IActionResult> GetOrderTracking([FromQuery] GetOrderTrackingInputModel request)
        {
            List<GetOrderTrackingViewModel> response = await _mediator.Send(request);

            if (response.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

    }
}
