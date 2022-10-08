using MediatR;
using WAAPI.Application.Extras;
using WAAPI.Application.Interfaces;

namespace WAAPI.Application.Queries.Pedidos
{
    public record GetTotalMoneySpent() : IRequest<Response>;

    public class GetTotalMoneySpentHandler : IRequestHandler<GetTotalMoneySpent, Response>
    {

        private readonly IRepositoryProduto _repository;

        public GetTotalMoneySpentHandler(IRepositoryProduto repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(GetTotalMoneySpent request, CancellationToken cancellationToken)
        {
            var totalMoneySpent = (await _repository.GetTotalMoneySpent());

            return new Response(totalMoneySpent);

        }

    }
}
