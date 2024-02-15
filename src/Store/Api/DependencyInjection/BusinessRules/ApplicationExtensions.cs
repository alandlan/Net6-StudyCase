using Net6StudyCase.SharedKernel.Caching;
using Net6StudyCase.Store.Application.UseCases;
using Net6StudyCase.Store.Domain.UseCases;

namespace Net6StudyCase.Auth.Api.DependencyInjection.BusinessRules
{
    internal static class ApplicationExtensions
    {
        internal static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICreateProduct, CreateProduct>();
            services.AddScoped<IGetProducts, GetProducts>();
            services.AddScoped<ICachingService, CachingService>();

            return services;
        }
    }
}
