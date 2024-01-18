using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Snap.Financials.Infrastructure.Database;
using Snap.Financials.Infrastructure.Users;
using Snap.Financials.Repositories;

namespace Snap.Financials.Infrastructure;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddDbContext<DatabaseContext>(options =>
          options.UseSqlite(configuration.GetConnectionString("Database")));

        services.AddScoped<SqlRepository>();

        services.AddScoped<ICustomerRepository>(s => s.GetRequiredService<SqlRepository>())
                .AddScoped<ICompanyInfoRepository>(s => s.GetRequiredService<SqlRepository>())
                .AddScoped<IInvoiceRepository>(s => s.GetRequiredService<SqlRepository>());

        return services;
    }

    public static IServiceCollection AddUserInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}