using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Financials.Infrastructure.Database.Models;

public class InvoiceLine : Entity
{
    [ForeignKey("Lines")]
    public Guid InvoiceId { get; set; }

    public Invoice Invoice { get; set; } = default!;
}

