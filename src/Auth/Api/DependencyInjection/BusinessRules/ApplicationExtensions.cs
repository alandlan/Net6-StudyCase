using Microsoft.Extensions.Configuration;
using Net6StudyCase.Auth.Application.Authorization.UseCases;
using Net6StudyCase.Auth.Domain.UseCases;
using Net6StudyCase.Auth.Infra.Identity;

namespace Net6StudyCase.Auth.Api.DependencyInjection.BusinessRules
{
    internal static class ApplicationExtensions
    {
        internal static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {

            services.AddScoped<ICreateUser,CreateUser>();
            services.AddScoped<ILogin,LogIn>();
            services.AddScoped<IGenerateToken,GenerateToken>();
            services.AddScoped<ITokenService,TokenService>();

            return services;
        }
    }
}
