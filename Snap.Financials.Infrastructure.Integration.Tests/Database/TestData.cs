using Snap.Financials.Infrastructure.Database;
using Snap.Financials.Infrastructure.Database.Models;

namespace Snap.Financials.Infrastructure.Integration.Tests.Database;

internal static class TestData
{
    public static DatabaseContext EnsureTestData(this DatabaseContext context)
    {
        var companyInfos = new List<CompanyInfo>
        {
            new() { Id = Guid.NewGuid(), Name = "test-name", Email="test-email", Address = "test-address", City="test-city", Province="test-province", Country="test-country", LogoUrl="test-logo-url" },
            new() { Id = Guid.NewGuid(), Name = "test-name-2", Email="test-email-2", Address = "test-address-2", City="test-city-2", Province="test-province-2", Country="test-country-2", LogoUrl="test-logo-url-2" },
            new() { Id = Guid.NewGuid(), Name = "test-name-3", Email="test-email-3", Address = "test-address-3", City="test-city-3", Province="test-province-3", Country="test-country-3", LogoUrl="test-logo-url-3" },

        };

        context.CompanyInfo.AddRange(companyInfos);

        var customers = new List<Customer>()
        {
               new() { Id = Guid.NewGuid(), Name = "test-name", Email="test-email", Address = "test-address", City="test-city", Province="test-province", Country="test-country"},
            new() { Id = Guid.NewGuid(), Name = "test-name-2", Email="test-email-2", Address = "test-address-2", City="test-city-2", Province="test-province-2", Country="test-country-2" },
            new() { Id = Guid.NewGuid(), Name = "test-name-3", Email="test-email-3", Address = "test-address-3", City="test-city-3", Province="test-province-3", Country="test-country-3" },
        };

        context.Customers.AddRange(customers);

        var invoices = new List<Invoice>()
        {
           
        };

        context.Invoices.AddRange(invoices);

        context.SaveChanges();

        return context;
    }
}

