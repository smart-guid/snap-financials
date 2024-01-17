using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snap.Financials.Infrastructure.Database.Models;

namespace Snap.Financials.Infrastructure.Database.Configuration;

internal class CustomerConfiguration : EntityConfiguration<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder.ToTable("tblCustomer");
        builder.Property(m => m.Name).IsRequired();
        builder.Property(m => m.Email).IsRequired();        
    }
}

