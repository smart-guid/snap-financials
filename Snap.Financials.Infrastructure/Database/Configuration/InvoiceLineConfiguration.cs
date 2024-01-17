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
    }
}

