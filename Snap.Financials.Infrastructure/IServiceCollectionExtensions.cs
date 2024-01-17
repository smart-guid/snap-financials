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

        services.AddSingleton<SqlRepository>();

        services.AddSingleton<ICustomerRepository>(s => s.GetRequiredService<SqlRepository>());
        services.AddSingleton<ICompanyInfoRepository>(s => s.GetRequiredService<SqlRepository>());
        services.AddSingleton<IInvoiceRepository>(s => s.GetRequiredService<SqlRepository>());

        return services;
    }

    public static IServiceCollection AddUserInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}