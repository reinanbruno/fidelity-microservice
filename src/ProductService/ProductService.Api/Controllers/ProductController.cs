using ProductService.Application.Queries.FilterCategories;
using ProductService.Application.Queries.FilterProducts;
using ProductService.Application.Queries.FilterSubCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Listar produtos disponíveis
        /// </summary>
        /// <response code="200">Dados obtidos com sucesso.</response>
        /// <response code="204">Não há itens.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public async Task<IActionResult> FilterProducts([FromQuery] FilterProductsInputModel request)
        {
            List<FilterProductsViewModel> response = await _mediator.Send(request);

            if (response.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        /// <summary>
        /// Listar categorias disponíveis
        /// </summary>
        /// <response code="200">Dados obtidos com sucesso.</response>
        /// <response code="204">Não há itens.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public async Task<IActionResult> FilterCategories([FromQuery] FilterCategoriesInputModel request)
        {
            List<FilterCategoriesViewModel> response = await _mediator.Send(request);

            if (response.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        /// <summary>
        /// Listar subcategorias disponíveis
        /// </summary>
        /// <response code="200">Dados obtidos com sucesso.</response>
        /// <response code="204">Não há itens.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public async Task<IActionResult> FilterSubCategories([FromQuery] FilterSubCategoriesInputModel request)
        {
            List<FilterSubCategoriesViewModel> response = await _mediator.Send(request);

            if (response.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

    }
}
