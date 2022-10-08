using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WAAPI.Application.Command.Pedidos;
using WAAPI.Application.Queries.Pedidos;

namespace WAAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPedidos();
            var response = await _mediator.Send(query);
            if (response.Errors.Count() != 0) return UnprocessableEntity();
            return Ok(response.Data);
        }

        [HttpGet("top5")]
        [Authorize]
        public async Task<IActionResult> GetTop5()
        {
            var query = new GetTop5Pedidos();
            var response = await _mediator.Send(query);
            if (response.Errors.Count() != 0) return UnprocessableEntity();
            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreatePedidoCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Errors.Count() != 0) return UnprocessableEntity();
            return Ok(response.Data);

        }
    }
}
