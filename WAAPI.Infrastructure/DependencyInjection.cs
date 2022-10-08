using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WAAPI.Application.Interfaces;
using WAAPI.Application.Interfaces.Services;
using WAAPI.Infrastructure.Context;
using WAAPI.Infrastructure.Repositories;
using WAAPI.Infrastructure.Services.JWT;

public static class DepencyInjection
{
    public static void ConfigureStartup(this IServiceCollection services, IConfiguration config)
    {

        ConfigureDB(services, config);
        ConfigureToken(services, config);
        services.AddTransient<IRepositoryUser, RepositoryUser>();
        services.AddTransient<IRepositoryPedido, RepositoryPedido>();
        services.AddTransient<IRepositoryProduto, RepositoryProduto>();
        services.AddTransient<IRepositoryEquipe, RepositoryEquipe>();
        services.AddHttpContextAccessor();
        services.AddScoped<ITokenService, TokenService>();
        var assembly = AppDomain.CurrentDomain.Load("WAAPI.Application");
        services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(assembly));
        services.AddMediatR(assembly);


    }

    public static void ConfigureDB(this IServiceCollection services, IConfiguration config)
    {

        services.AddDbContext<ApplicationDbContext>(options =>{options.UseSqlite(config.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("WAAPI.Infrastructure"));});

    }


    public static void ConfigureToken(this IServiceCollection services, IConfiguration config)
    {

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

        services.AddAuthorization();
    }

}
