using Microsoft.Extensions.DependencyInjection;
using CreditCardValidatorApi.Application.Interfaces;
using CreditCardValidatorApi.Infrastructure.Repositories;

namespace CreditCardValidatorApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        } 
    }
}
