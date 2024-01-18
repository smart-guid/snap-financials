namespace Snap.Financials.Infrastructure.Database.Models;

public class InvoiceLine : Entity
{
    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public int Quantity { get; set; } = default!;

    public string QuantityDescription { get; set; } = default!;

    public decimal Price { get; set; }

    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = default!;
}

