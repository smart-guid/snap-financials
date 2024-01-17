using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snap.Financials.Infrastructure.Database.Models;

namespace Snap.Financials.Infrastructure.Database.Configuration;

internal abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(m => m.DateCreated).ValueGeneratedOnAdd().IsRequired();
        builder.Property(m => m.DateModified).ValueGeneratedOnAdd().IsRequired();
    }
}