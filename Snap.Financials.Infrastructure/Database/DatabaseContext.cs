using Microsoft.EntityFrameworkCore;
using Snap.Financials.Infrastructure.Database.Models;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyInfo>().ToTable("tblCompany");
        modelBuilder.Entity<Customer>().ToTable("tblCustomer");
        modelBuilder.Entity<Invoice>().ToTable("tblInvoice");
    }
}