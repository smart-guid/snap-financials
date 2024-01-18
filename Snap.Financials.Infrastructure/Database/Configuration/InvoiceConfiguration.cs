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

        builder.HasOne(i => i.Customer)       
               .WithMany(m => m.Invoices)     
               .HasForeignKey(f => f.CustomerId); 
       
        builder.Property(m => m.InvoiceNumber).HasMaxLength(10).IsRequired();
        builder.Property(m => m.InvoiceDate).IsRequired();
        builder.Property(m => m.DueDate).IsRequired();
        builder.Property(m => m.PaymentTerms).HasMaxLength(20).IsRequired();
        builder.Property(m => m.PaymentInstructions).HasMaxLength(200);
        builder.Property(m => m.CustomerId).IsRequired();
    }
}

