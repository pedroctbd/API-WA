using MediatR;
using WAAPI.Application.Extras;
using WAAPI.Application.Interfaces;

namespace WAAPI.Application.Queries.Pedidos
{
    public record GetAllPedidos() : IRequest<Response>;

    public class GetAllPedidosHandler : IRequestHandler<GetAllPedidos, Response>
    {

        private readonly IRepositoryPedido _repository;

        public GetAllPedidosHandler(IRepositoryPedido repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(GetAllPedidos request, CancellationToken cancellationToken)
        {
            var pedidos = (await _repository.GetAllPedidos());

            return new Response(pedidos);
        }
    }
}
