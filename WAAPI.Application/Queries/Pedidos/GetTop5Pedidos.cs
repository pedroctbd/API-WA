using MediatR;
using WAAPI.Application.Extras;
using WAAPI.Application.Interfaces;

namespace WAAPI.Application.Queries.Pedidos
{
    public record GetTop5Pedidos() : IRequest<Response>;

    public class GetTop5PedidosHandler : IRequestHandler<GetTop5Pedidos, Response>
    {

        private readonly IRepositoryPedido _repository;

        public GetTop5PedidosHandler(IRepositoryPedido repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(GetTop5Pedidos request, CancellationToken cancellationToken)
        {
            var pedidos = (await _repository.GetTop5Pedidos());

            return new Response(pedidos);
        }
    }
}
