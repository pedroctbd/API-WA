using FluentValidation;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using WAAPI.Application.Extras;
using WAAPI.Application.Interfaces;
using WAAPI.Domain.Entities;

namespace WAAPI.Application.Users.Command
{
    public record CreateUserCommand(String UserName, String Password, String Email) : IRequest<Response>;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response>
    {

        private readonly IRepositoryUser _repository;


        public CreateUserCommandHandler(IRepositoryUser repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = request.UserName.ToLower(),
                Email = request.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                PasswordSalt = hmac.Key
            };

            _repository.Add(user);

            return new Response(user);

        }
    }
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IRepositoryUser repository;

        public CreateUserCommandValidator(IRepositoryUser repository)
        {

            RuleFor(newUser => newUser.UserName).NotEmpty().MaximumLength(100);
            RuleFor(newUser => newUser.Email).NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(newUser => newUser.Password).NotEmpty().MaximumLength(12).MinimumLength(4);
            RuleFor(newuser => newuser).MustAsync(async (newuser, _) => repository.GetUserByEmail(newuser.Email).Result == null).WithMessage("Email taken");

        }
    }

}


