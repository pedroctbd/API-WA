using FluentValidation;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using WAAPI.Application.Extras;
using WAAPI.Application.Interfaces;
using WAAPI.Application.Interfaces.Services;
using WAAPI.Application.Models.DAOs;

namespace WAAPI.Application.Command.Auth
{
    public record LoginAuthCommand(String Password, String Email) : IRequest<Response>;

    public class LoginAuthCommandHandler : IRequestHandler<LoginAuthCommand, Response>
    {

        private readonly IRepositoryUser _repository;
        private readonly ITokenService _tokenService;

        public LoginAuthCommandHandler(IRepositoryUser repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public async Task<Response> Handle(LoginAuthCommand request, CancellationToken cancellationToken)
        {

            Response r = new Response();
            var existingUser = _repository.GetUserByEmail(request.Email).Result;

            using var hmac = new HMACSHA512(existingUser.PasswordSalt);
            var hashLogin = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

            for (int i = 0; i < hashLogin.Length; i++)
            {
                if (hashLogin[i] != existingUser.PasswordHash[i])
                {
                    r.AddError("Passoword", "Incorret Password");
                    return r;
                }
            }

            var jwt = new JwtDao
            {
                Id = existingUser.Id,
                UserName = existingUser.UserName,
                Email = request.Email,
                Token = _tokenService.CreateToken(existingUser)
            };
            return new Response(jwt);


        }

        public class LoginAuthCommandValidator : AbstractValidator<LoginAuthCommand>
        {
            private readonly IRepositoryUser repository;

            public LoginAuthCommandValidator(IRepositoryUser repository)
            {

                RuleFor(newUser => newUser).MustAsync(async (newUser, _) => repository.GetUserByEmail(newUser.Email).Result!=null).WithMessage("User not found");

            }
        
        }
    }

}
