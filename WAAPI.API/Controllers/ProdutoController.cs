using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WAAPI.Application.Queries.Pedidos;

namespace WAAPI.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTotalMoneySpent()
        {
            var query = new GetTotalMoneySpent();
            var response = await _mediator.Send(query);
            if (response.Errors.Count() != 0) return UnprocessableEntity();
            return Ok(response.Data);
        }

    }
}
