using Microsoft.EntityFrameworkCore;
using Snap.Financials.Infrastructure.Database.Models;
using System.Reflection;

namespace Snap.Financials.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<CompanyInfo> CompanyInfo { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceLine> InvoiceLines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}