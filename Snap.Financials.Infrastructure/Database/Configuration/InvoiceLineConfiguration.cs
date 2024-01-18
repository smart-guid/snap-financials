using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snap.Financials.Infrastructure.Database.Models;

namespace Snap.Financials.Infrastructure.Database.Configuration;

internal class InvoiceLineConfiguration : EntityConfiguration<InvoiceLine>
{
    public override void Configure(EntityTypeBuilder<InvoiceLine> builder)
    {
        base.Configure(builder);

        builder.ToTable("tblInvoiceLine");

        builder.HasOne(i => i.Invoice)
               .WithMany(m => m.Lines)
               .HasForeignKey(f => f.InvoiceId);

        builder.Property(m => m.Title).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(100);
        builder.Property(m => m.QuantityDescription).HasMaxLength(10).IsRequired();
        builder.Property(m => m.Quantity).IsRequired();
        builder.Property(m => m.Price).IsRequired();
        builder.Property(m => m.InvoiceId).IsRequired();
    }
}

