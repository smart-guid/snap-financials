namespace Snap.Financials.Models;

public class InvoiceModel
{
    public Guid Id { get; set; }

    public string InvoiceNumber { get; set; } = default!;

    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }

    public string PaymentTerms { get; set; } = default!;
    public string PaymentInstructions { get; set; } = default!;

    public CustomerModel Customer { get; set; } = default!;
}

