using MediatR;
using WAAPI.Application.Extras;
using WAAPI.Application.Interfaces;

namespace WAAPI.Application.Queries.Pedidos
{
    public record GetTotalEquipes() : IRequest<Response>;

    public class GetTotalEquipesHandler : IRequestHandler<GetTotalEquipes, Response>
    {

        private readonly IRepositoryEquipe _repository;

        public GetTotalEquipesHandler(IRepositoryEquipe repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(GetTotalEquipes request, CancellationToken cancellationToken)
        {
            var totalMoneySpent = (await _repository.GetTotalEquipes());

            return new Response(totalMoneySpent);

        }

    }
}
