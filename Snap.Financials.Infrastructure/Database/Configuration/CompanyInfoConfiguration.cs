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
        builder.Property(m => m.Name).HasMaxLength(200).IsRequired();
        builder.Property(m => m.Email).HasMaxLength(50).IsRequired();
        builder.Property(m => m.PhoneNumber).HasMaxLength(15).IsRequired();
        builder.Property(m => m.Address).HasMaxLength(100).IsRequired();
        builder.Property(m => m.City).HasMaxLength(50).IsRequired();
        builder.Property(m => m.Province).HasMaxLength(20).IsRequired();
        builder.Property(m => m.Country).HasMaxLength(50).IsRequired();
        builder.Property(m => m.LogoUrl).HasMaxLength(200).IsRequired();
    }
}
