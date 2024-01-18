namespace Snap.Financials.Infrastructure.Database.Models;

public class Invoice : Entity
{
    public string InvoiceNumber { get; set; } = default!;

    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }

    public string PaymentTerms { get; set; } = default!;
    public string PaymentInstructions { get; set; } = default!;
 
    public Guid CustomerId { get; set; } = default!;
    public Customer Customer { get; set; } = default!;

    public ICollection<InvoiceLine> Lines { get; set; } = default!;
}
