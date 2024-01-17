using System.ComponentModel.DataAnnotations.Schema;

namespace Snap.Financials.Infrastructure.Database.Models;

public class Invoice : Entity
{
    [InverseProperty("Lines")]
    public ICollection<InvoiceLine> Lines { get; set; } = default!;
}
