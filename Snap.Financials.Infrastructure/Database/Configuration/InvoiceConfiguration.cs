using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snap.Financials.Infrastructure.Database.Models;

namespace Snap.Financials.Infrastructure.Database.Configuration;

internal class InvoiceConfiguration : EntityConfiguration<Invoice>
{
    public override void Configure(EntityTypeBuilder<Invoice> builder)
    {
        base.Configure(builder);


        builder.ToTable("tblInvoice");

        builder.HasMany(f => f.Lines).WithOne(o => o.Invoice).HasForeignKey(k => k.InvoiceId);

        //builder.Property(m => m.Name).IsRequired();
        //builder.Property(m => m.Email).IsRequired();
    }
}

