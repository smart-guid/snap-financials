namespace Snap.Financials.Models;

public class InvoiceLineModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public int Quantity { get; set; } = default!;

    public string QuantityDescription { get; set; } = default!;

    public decimal Price { get; set; }
}

