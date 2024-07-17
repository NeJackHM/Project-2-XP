using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestCaseXp.Application.Features.Commands.Customer;
using TestCaseXp.Application.Features.Commands.Transaction;
using TestCaseXp.Application.Features.Queries.Customer;
using TestCaseXp.Application.Features.Queries.Transaction;
using TestCaseXp.Domain.DataAccess.Repositories;
using TestCaseXp.Infrastructure.DataAccess.Repositories;

namespace TestCaseXp.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IRequestHandler<GetCustomerRequest, GetCustomerResponse>, GetCustomerRequestHandler>();
            services.AddTransient<IRequestHandler<GetAllCustomerRequest, GetAllCustomerResponse>, GetAllCustomerRequestHandler>();
            services.AddTransient<IRequestHandler<RegisterCustomerRequest, RegisterCustomerResponse>, RegisterCustomerRequestHandler>();
            services.AddTransient<IRequestHandler<RegisterTransactionRequest, RegisterTransactionResponse>, RegisterTransactionRequestHandler>();
            services.AddTransient<IRequestHandler<GetTransactionReportRequest, GetTransactionReportResponse>, GetTransactionReportRequestHandler>();

            return services;
        }
    }
}