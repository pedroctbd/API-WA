using FluentValidation;
using MediatR;
using WAAPI.Application.Extras;
using WAAPI.Application.Interfaces;
using WAAPI.Domain.Entities;

namespace WAAPI.Application.Command.Pedidos
{
    public record CreatePedidoCommand(string Endereco, DateTimeOffset DataEntrega, List<CreateProdutoCommand> Produtos, CreateEquipeCommand Equipe) : IRequest<Response>;
    public record CreateProdutoCommand(string Nome,float Valor,string Descricao);
    public record CreateEquipeCommand(string Nome,string Descricao,string PlacaVeiculo);


    public class CreatePedidoCommandHandler : IRequestHandler<CreatePedidoCommand, Response>
    {

        private readonly IRepositoryPedido _repository;
        private readonly IRepositoryProduto _repositoryProduto;



        public CreatePedidoCommandHandler(IRepositoryPedido repository, IRepositoryProduto repositoryProduto)
        {
            _repository = repository;
            _repositoryProduto = repositoryProduto;

        }

        public async Task<Response> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            var equipe = new Equipe(request.Equipe.Nome, request.Equipe.Descricao, request.Equipe.PlacaVeiculo);
            var pedido = new Pedido(request.DataEntrega,request.Endereco,equipe);
           
            _repository.Add(pedido);
            foreach (var produto in request.Produtos)
            {
                var newProduto = new Produto(produto.Nome, produto.Valor, produto.Descricao);
                _repositoryProduto.Add(newProduto);
                pedido.PedidoProduto.Add(new PedidoProduto
                {
                    IdPedido = pedido.Id,
                    IdProduto = newProduto.Id
                });
            }
            _repository.Update(pedido);

            return new Response(request);
        }
    }

    public class CreatePedidoCommandValidator : AbstractValidator<CreatePedidoCommand>
    {

        private readonly IRepositoryPedido repository;

        public CreatePedidoCommandValidator(IRepositoryPedido repository)
        {

            RuleFor(newPedido => newPedido.Endereco).NotEmpty().MaximumLength(200);
            RuleFor(newPedido => newPedido.Produtos).NotEmpty();
            RuleFor(newPedido => newPedido.Equipe).NotEmpty();
            RuleFor(newPedido => newPedido.DataEntrega).Must(BeAValidDate);

        }
        private bool BeAValidDate(DateTimeOffset date)
        {
            return !date.Equals(default(DateTimeOffset));
        }

    }

}
