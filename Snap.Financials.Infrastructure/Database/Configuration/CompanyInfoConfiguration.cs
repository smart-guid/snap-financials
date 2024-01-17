using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snap.Financials.Infrastructure.Database.Models;

namespace Snap.Financials.Infrastructure.Database.Configuration;

internal class CompanyInfoConfiguration : EntityConfiguration<CompanyInfo>
{
    public override void Configure(EntityTypeBuilder<CompanyInfo> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("tblCompany");
        builder.Property(m => m.Name).IsRequired();
        builder.Property(m => m.Email).IsRequired();
    }
}
